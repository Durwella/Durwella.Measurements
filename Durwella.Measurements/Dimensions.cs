using System.Collections.Generic;

namespace Measurements
{
    public static class Dimensions
    {
        private class KeyComparer : IEqualityComparer<Dimension>
        {
            public bool Equals(Dimension dimension1, Dimension dimension2)
            {
                return dimension1.Equals(dimension2);
            }

            public int GetHashCode(Dimension dimension)
            {
                return dimension.GetHashCode();
            }
        }

        internal static Dictionary<Dimension, Dimension> CompoundDimensions = new Dictionary<Dimension, Dimension>(new KeyComparer());

        // Basic Physical Dimensions
        public static Dimension Length = new Dimension("Length");
        public static Dimension Time = new Dimension("Time");
        public static Dimension Mass = new Dimension("Mass");
        public static Dimension[] Basic = new[] { Length, Time, Mass };

        // Derived / Composite / Compound Physical Dimensions
        public static Dimension Area = new Dimension("Area", Length * Length);
        public static Dimension Volume = new Dimension("Volume", Length * Length * Length);
        public static Dimension Density = new Dimension("Density", Mass / Volume);
        public static Dimension Frequency = new Dimension("Frequency", Time.Inverse());
        public static Dimension Velocity = new Dimension("Velocity", Length / Time);
        public static Dimension Acceleration = new Dimension("Acceleration", Velocity / Time);
        public static Dimension Force = new Dimension("Force", Mass * Acceleration);
        public static Dimension Pressure = new Dimension("Pressure", Force / Area);
    }
}
