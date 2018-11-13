using System.Collections.Generic;

namespace Durwella.Measurements
{
    public static class Dimensions
    {
        // Basic Physical Dimensions
        public static Dimension Length = new Dimension("Length");
        public static Dimension Time = new Dimension("Time");
        public static Dimension Mass = new Dimension("Mass");
        public static Dimension[] Basic = new[] { Length, Time, Mass };

        // Derived Physical Dimensions
        internal static Dictionary<Dimension, Dimension> DerivedDimensions = new Dictionary<Dimension, Dimension>();

        public static Dimension Area = new Dimension("Area", Length * Length);
        public static Dimension Volume = new Dimension("Volume", Length * Length * Length);
        public static Dimension Density = new Dimension("Density", Mass / Volume);
        public static Dimension Frequency = new Dimension("Frequency", Time.Inverse());
        public static Dimension Velocity = new Dimension("Velocity", Length / Time);
        public static Dimension Acceleration = new Dimension("Acceleration", Velocity / Time);
        public static Dimension VolumeFlowRate = new Dimension("Volume Flow Rate", Volume / Time);
        public static Dimension Force = new Dimension("Force", Mass * Acceleration);
        public static Dimension Pressure = new Dimension("Pressure", Force / Area);
    }
}
