using System.Collections.Generic;

namespace Measurements
{
    /// <summary>
    /// The International System of Units (SI) or Metric System.
    /// </summary>
    public class SiSystem : IUnitSystem
    {
        private readonly Dictionary<Dimension, UnitOfMeasurement> _baseDimensions = new Dictionary<Dimension, UnitOfMeasurement>
        {
            { Dimensions.Length, Units.Meters },
            { Dimensions.Mass, Units.Kilograms },
            { Dimensions.Time, Units.Seconds },
        };

        public UnitOfMeasurement this[Dimension dimension] =>
            _baseDimensions[dimension];
    }
}
