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

        private readonly UnitOfMeasurement[] _lengthUnits = new[]
        {
            Units.Millimeters,
            Units.Centimeters,
            Units.Meters,
            Units.Kilometers
        };

        private readonly UnitOfMeasurement[] _massUnits = new[]
        {
            Units.Grams,
            Units.Kilograms
        };

        public UnitOfMeasurement this[Dimension dimension] =>
            _baseDimensions[dimension];

        public IEnumerable<UnitOfMeasurement> GetUnits(Dimension dimension)
        {
            if (dimension == Dimensions.Length)
                return _lengthUnits;
            if (dimension == Dimensions.Mass)
                return _massUnits;
            if (dimension == Dimensions.Time)
                return Units.OfTime;
            throw new KeyNotFoundException(dimension.Name);
        }
    }
}
