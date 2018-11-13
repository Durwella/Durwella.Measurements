using System.Collections.Generic;
using static Durwella.Measurements.Dimensions;
using static Durwella.Measurements.Units;

namespace Durwella.Measurements
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
            { VolumeFlowRate, CubicMetersPerSecond },
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

        private readonly UnitOfMeasurement[] _volumeUnits = new[]
        {
            CubicCentimeters,
            CubicDecimeters,
            CubicMeters,
            Liters
        };

        private readonly UnitOfMeasurement[] _velocityUnits = new[]
        {
            MetersPerSecond,
            KilometersPerHour
        };

        private readonly UnitOfMeasurement[] _flowUnits = new[]
        {
            CubicMetersPerSecond,
            CubicMetersPerHour
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
            if (dimension == Volume)
                return _volumeUnits;
            if (dimension == VolumeFlowRate)
                return _flowUnits;
            else if (_baseDimensions.ContainsKey(dimension))
                return new[] { this[dimension] };
            throw new KeyNotFoundException(dimension.Name);
        }
    }
}
