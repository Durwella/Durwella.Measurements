using System.Collections.Generic;

namespace Measurements
{
    /// <summary>
    /// The United States Customary System of Units (USCS or USC).
    /// Sometimes referred to as the Imperial system, although technically different.
    /// </summary>
    public class UscSystem : IUnitSystem
    {
        private readonly Dictionary<Dimension, Measurement> _baseTypes = new Dictionary<Dimension, Measurement>
        {
            { MeasurementTypes.Length, Units.Feet },
            { MeasurementTypes.Mass, Units.PoundsMass },
            { MeasurementTypes.Time, Units.Seconds },
        };

        public Measurement this[Dimension dimension] =>
            _baseTypes[dimension];
    }
}
