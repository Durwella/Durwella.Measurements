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
        private readonly Dictionary<Dimension, UnitOfMeasurement> _baseDimensions = new Dictionary<Dimension, UnitOfMeasurement>
        {
            // Basic
            { Length, Feet },
            { Mass, PoundsMass },
            { Time, Seconds },
            // Derived
            { Area, SquareFeet },
            { Volume, CubicFeet },
            { Density, SlugsPerCubicFoot },
            { Velocity, FeetPerSecond },
            { Acceleration, FeetPerSecondSquared },
            { Force, PoundsForce },
            { Pressure, PoundsPerSquareInch },
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

        private readonly UnitOfMeasurement[] _velocityUnits = new[]
        {
            FeetPerSecond,
            FeetPerMinute,
            FeetPerHour,
            MilesPerHour
        };

        public IEnumerable<Dimension> Dimensions => PredefinedSystems.Dimensions;

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
            if (dimension == Velocity)
                return _velocityUnits;
            else if (_baseDimensions.ContainsKey(dimension))
                return new[] { this[dimension] };
            throw new KeyNotFoundException(dimension.Name);
        }
    }
}
