using System.Collections.Generic;

namespace Measurements
{
    /// <summary>
    /// The International System of Units (SI) or Metric System.
    /// </summary>
    public class SiSystem : IUnitSystem
    {
        private readonly Dictionary<Dimension, Measurement> _baseTypes = new Dictionary<Dimension, Measurement>
        {
            { MeasurementTypes.Length, Units.Meters },
            { MeasurementTypes.Mass, Units.Kilograms },
            { MeasurementTypes.Time, Units.Seconds },
        };

        public Measurement this[Dimension dimension] =>
            _baseTypes[dimension];
    }
}
