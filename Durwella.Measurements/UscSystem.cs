using System.Collections.Generic;

namespace Measurements
{
    /// <summary>
    /// The United States Customary System of Units (USCS or USC).
    /// Sometimes referred to as the Imperial system, although technically different.
    /// </summary>
    public class UscSystem : IUnitSystem
    {
        private readonly Dictionary<Dimension, Measurement> _baseDimensions = new Dictionary<Dimension, Measurement>
        {
            { Dimensions.Length, Units.Feet },
            { Dimensions.Mass, Units.PoundsMass },
            { Dimensions.Time, Units.Seconds },
        };

        public Measurement this[Dimension dimension] =>
            _baseDimensions[dimension];
    }
}
