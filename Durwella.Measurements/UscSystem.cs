using System.Collections.Generic;

namespace Measurements
{
    /// <summary>
    /// The United States Customary System of Units (USCS or USC).
    /// Sometimes referred to as the Imperial system, although technically different.
    /// </summary>
    public class UscSystem : IUnitSystem
    {
        private readonly Dictionary<Dimension, UnitOfMeasurement> _baseDimensions = new Dictionary<Dimension, UnitOfMeasurement>
        {
            { Dimensions.Length, Units.Feet },
            { Dimensions.Mass, Units.PoundsMass },
            { Dimensions.Time, Units.Seconds },
        };

        public UnitOfMeasurement this[Dimension dimension] =>
            _baseDimensions[dimension];
    }
}
