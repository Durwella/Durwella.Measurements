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

        private readonly UnitOfMeasurement[] _lengthUnits = new[]
        {
            Units.Inches,
            Units.Feet,
            Units.Yards,
            Units.Miles
        };

        private readonly UnitOfMeasurement[] _massUnits = new[]
        {
            Units.Ounces,
            Units.PoundsMass,
            Units.Slug,
            Units.ShortTons,
        };

        private readonly UnitOfMeasurement[] _timeUnits = new[]
        {
            Units.Seconds,
            Units.Minutes,
            Units.Hours,
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
                return _timeUnits;
            throw new KeyNotFoundException(dimension.Name);
        }
    }
}
