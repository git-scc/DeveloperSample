using System;
using System.Collections.Generic;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African,
        European
    }

    public enum SwallowLoad
    {
        None,
        Coconut
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; } = SwallowLoad.None;

        // Lookup table for all speeds
        private static readonly Dictionary<(SwallowType, SwallowLoad), double> SpeedMap =
            new()
            {
                { (SwallowType.African, SwallowLoad.None), 22 },
                { (SwallowType.African, SwallowLoad.Coconut), 18 },
                { (SwallowType.European, SwallowLoad.None), 20 },
                { (SwallowType.European, SwallowLoad.Coconut), 16 }
            };

        public Swallow(SwallowType type)
        {
            Type = type;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            if (SpeedMap.TryGetValue((Type, Load), out var speed))
                return speed;

            throw new InvalidOperationException(
                $"Unsupported combination: {Type} with {Load}");
        }
    }
}