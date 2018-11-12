using System.Collections.Generic;
using static Measurements.Dimensions;
using static Measurements.Units;

namespace Measurements
{
    /// <summary>
    /// The United States Customary System of Units (USCS or USC).
    /// Sometimes referred to as the Imperial system, although technically different.
    /// </summary>
    public class UscSystem : IUnitSystem
    {
        private readonly Dimension[] _dimensions = new[]
        {
            // Basic
            Length,
            Mass,
            Time,
            // Derived
            Pressure,
            Force
        };

        private readonly Dictionary<Dimension, UnitOfMeasurement> _baseDimensions = new Dictionary<Dimension, UnitOfMeasurement>
        {
            // Basic
            { Length, Feet },
            { Mass, PoundsMass },
            { Time, Seconds },
            // Derived
            { Pressure, PoundsPerSquareInch },
            { Force, PoundsForce }
        };

        private readonly UnitOfMeasurement[] _lengthUnits = new[]
        {
            Inches,
            Feet,
            Yards,
            Miles
        };

        private readonly UnitOfMeasurement[] _massUnits = new[]
        {
            Ounces,
            PoundsMass,
            Slugs,
            ShortTons,
        };

        private readonly UnitOfMeasurement[] _pressureUnits = new[]
        {
            PoundsPerSquareInch
        };

        private readonly UnitOfMeasurement[] _forceUnits = new[]
        {
            PoundsForce
        };

        public IEnumerable<Dimension> Dimensions => _dimensions;

        public virtual UnitOfMeasurement this[Dimension dimension] =>
            _baseDimensions[dimension];

        public virtual IEnumerable<UnitOfMeasurement> GetUnits(Dimension dimension)
        {
            if (dimension == Length)
                return _lengthUnits;
            if (dimension == Mass)
                return _massUnits;
            if (dimension == Time)
                return OfTime;
            if (dimension == Pressure)
                return _pressureUnits;
            if (dimension == Force)
                return _forceUnits;
            throw new KeyNotFoundException(dimension.Name);
        }
    }
}
