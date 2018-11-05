using System.Collections.Generic;

namespace Measurements
{
    /// <summary>
    /// The International System of Units (SI) or Metric System.
    /// </summary>
    public class SiSystem : IUnitSystem
    {
        private readonly Dictionary<MeasurementType, Measurement> _baseTypes = new Dictionary<MeasurementType, Measurement>
        {
            { MeasurementTypes.Length, Units.Meters },
            { MeasurementTypes.Mass, Units.Kilograms },
            { MeasurementTypes.Time, Units.Seconds },
        };

        public Measurement this[MeasurementType measurementType] =>
            _baseTypes[measurementType];
    }
}
