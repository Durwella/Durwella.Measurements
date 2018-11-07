using System.Collections.Generic;

namespace Measurements
{
    /// <summary>
    /// The International System of Units (SI) or Metric System.
    /// </summary>
    public class SiSystem : IUnitSystem
    {
        private readonly Dictionary<Dimension, Measurement> _baseDimensions = new Dictionary<Dimension, Measurement>
        {
            { Dimensions.Length, Units.Meters },
            { Dimensions.Mass, Units.Kilograms },
            { Dimensions.Time, Units.Seconds },
        };

        public Measurement this[Dimension dimension] =>
            _baseDimensions[dimension];
    }
}
