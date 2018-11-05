using System.Collections.Generic;

namespace Measurements
{
    /// <summary>
    /// The United States Customary System of Units (USCS or USC).
    /// Sometimes referred to as the Imperial system, although technically different.
    /// </summary>
    public class UscSystem : IUnitSystem
    {
        private readonly Dictionary<MeasurementType, Measurement> _baseTypes = new Dictionary<MeasurementType, Measurement>
        {
            { MeasurementTypes.Length, Units.Feet },
            { MeasurementTypes.Mass, Units.PoundsMass },
            { MeasurementTypes.Time, Units.Seconds },
        };

        public Measurement this[MeasurementType measurementType] =>
            _baseTypes[measurementType];
    }
}
