<<<<<<< HEAD
using System;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n) => throw new NotImplementedException();

        public static string FormatSeparators(params string[] items) => throw new NotImplementedException();
    }
=======
using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        //public static int GetFactorial(int n) => throw new NotImplementedException();
        
        // Calculates factorial of n (n!)
        public static int GetFactorial(int n)
        {
            if (n < 0) throw new ArgumentException("n must be >= 0");
            int result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }

        //public static string FormatSeparators(params string[] items) => throw new NotImplementedException();

        // Formats array of strings: "a", "b", "c" => "a, b and c"
        public static string FormatSeparators(params string[] items)
        {
            if (items == null || items.Length == 0) return "";
            if (items.Length == 1) return items[0];
            if (items.Length == 2) return $"{items[0]} and {items[1]}";

            var allButLast = items.Take(items.Length - 1);
            var last = items.Last();
            return $"{string.Join(", ", allButLast)} and {last}";
        }
    }
>>>>>>> 25d79f0 (Completed DeveloperSample assessment: frontend and backend)
}