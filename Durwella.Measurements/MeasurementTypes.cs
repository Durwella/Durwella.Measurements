using System.Collections.Generic;

namespace Measurements
{
    public static class MeasurementTypes
    {
        private class KeyComparer: IEqualityComparer<Dimension>
        {
            public bool Equals(Dimension type1, Dimension type2)
            {
                return type1.Equals(type2);
            }

            public int GetHashCode(Dimension type)
            {
                return type.GetHashCode();
            }
        }
        public static Dictionary<Dimension, Dimension> CompoundTypes = new Dictionary<Dimension, Dimension>(new KeyComparer());

        public static Dimension Length        = new Dimension("Length");
        public static Dimension Time          = new Dimension("Time");
        public static Dimension Mass          = new Dimension("Mass");

        // Compound Types
        public static Dimension Area          = new Dimension("Area", Length * Length);
        public static Dimension Volume        = new Dimension("Volume", Length * Length * Length);
        public static Dimension Density       = new Dimension("Density", Mass / Volume);
        public static Dimension Frequency     = new Dimension("Frequency", Time.Inverse());
        public static Dimension Velocity      = new Dimension("Velocity", Length / Time);
        public static Dimension Acceleration  = new Dimension("Acceleration", Velocity / Time);
        public static Dimension Force         = new Dimension("Force", Mass * Acceleration);
        public static Dimension Pressure      = new Dimension("Pressure", Force / Area);
    }
}
