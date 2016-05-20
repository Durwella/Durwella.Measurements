using System.Collections.Generic;

namespace Measurements
{
    public static class MeasurementTypes
    {
        private class KeyComparer: IEqualityComparer<MeasurementType>
        {
            public bool Equals(MeasurementType type1, MeasurementType type2)
            {
                return type1.Equals(type2);
            }

            public int GetHashCode(MeasurementType type)
            {
                return type.GetHashCode();
            }
        }
        public static Dictionary<MeasurementType, MeasurementType> CompoundTypes = new Dictionary<MeasurementType, MeasurementType>(new KeyComparer());

        public static MeasurementType Length        = new MeasurementType("Length");
        public static MeasurementType Time          = new MeasurementType("Time");
        public static MeasurementType Mass          = new MeasurementType("Mass");

        // Compound Types
        public static MeasurementType Area          = new MeasurementType("Area", Length * Length);
        public static MeasurementType Volume        = new MeasurementType("Volume", Length * Length * Length);
        public static MeasurementType Density       = new MeasurementType("Density", Mass / Volume);
        public static MeasurementType Frequency     = new MeasurementType("Frequency", Time.Inverse());
        public static MeasurementType Velocity      = new MeasurementType("Velocity", Length / Time);
        public static MeasurementType Acceleration  = new MeasurementType("Acceleration", Velocity / Time);
        public static MeasurementType Force         = new MeasurementType("Force", Mass * Acceleration);
        public static MeasurementType Pressure      = new MeasurementType("Pressure", Force / Area);
    }
}
