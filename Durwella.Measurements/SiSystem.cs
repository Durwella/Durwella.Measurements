using System.Collections.Generic;
using static Measurements.Dimensions;
using static Measurements.Units;

namespace Measurements
{
    /// <summary>
    /// The International System of Units (SI) or Metric System.
    /// </summary>
    public class SiSystem : IUnitSystem
    {
        private readonly Dictionary<Dimension, UnitOfMeasurement> _baseDimensions = new Dictionary<Dimension, UnitOfMeasurement>
        {
            // Basic
            { Length, Meters },
            { Mass, Kilograms },
            { Time, Seconds },
            // Derived
            { Area, SquareMeters },
            { Volume, CubicMeters },
            { Density, KilogramsPerCubicMeter },
            { Velocity, MetersPerSecond },
            { Acceleration, MetersPerSecondSquared },
            { Force, Newtons },
            { Pressure, Pascals },
        };

        private readonly UnitOfMeasurement[] _lengthUnits = new[]
        {
            Millimeters,
            Centimeters,
            Meters,
            Kilometers
        };

        private readonly UnitOfMeasurement[] _massUnits = new[]
        {
            Grams,
            Kilograms
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
            else if (_baseDimensions.ContainsKey(dimension))
                return new[] { this[dimension] };
            throw new KeyNotFoundException(dimension.Name);
        }
    }
}
