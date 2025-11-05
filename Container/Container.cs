<<<<<<< HEAD
using System;

namespace DeveloperSample.Container
{
    public class Container
    {
        public void Bind(Type interfaceType, Type implementationType) => throw new NotImplementedException();
        public T Get<T>() => throw new NotImplementedException();
    }
=======
using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        //public void Bind(Type interfaceType, Type implementationType) => throw new NotImplementedException();
        private readonly Dictionary<Type, Type> _bindings = new();
        public void Bind(Type interfaceType, Type implementationType)
        {
            _bindings[interfaceType] = implementationType;
        }
        //public T Get<T>() => throw new NotImplementedException();

        public T Get<T>()
        {
            var interfaceType = typeof(T);

            if (!_bindings.ContainsKey(interfaceType))
                throw new InvalidOperationException($"No binding for type {interfaceType.Name}");

            var implementationType = _bindings[interfaceType];
            return (T)Activator.CreateInstance(implementationType);
        }
    }
>>>>>>> 25d79f0 (Completed DeveloperSample assessment: frontend and backend)
}