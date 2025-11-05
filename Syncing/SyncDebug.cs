using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            Parallel.ForEach(items, i =>
            {
                bag.Add(i);
            });
            return bag.ToList();
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            // Ensure per-key initialization happens ONCE using Lazy<T>
            var concurrentDictionary = new ConcurrentDictionary<int, Lazy<string>>();

            var threads = Enumerable.Range(0, 3)
                .Select(_ => new Thread(() =>
                {
                    foreach (var key in itemsToInitialize)
                    {
                        var lazy = concurrentDictionary.GetOrAdd(
                            key,
                            k => new Lazy<string>(() => getItem(k), LazyThreadSafetyMode.ExecutionAndPublication)
                        );
                        // Force value creation
                        var _unused = lazy.Value;
                    }
                }))
                .ToList();

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value.Value);
        }
    }
}
