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
            { Length, Meters },
            { Mass, Kilograms },
            { Time, Seconds },
            // Derived
            { Pressure, Pascals },
            { Force, Newtons }
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

        private readonly UnitOfMeasurement[] _pressureUnits = new[]
        {
            Pascals
        };

        private readonly UnitOfMeasurement[] _forceUnits = new[]
        {
            Newtons
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
