﻿using System;

namespace Durwella.Measurements
{
    /// <summary>
    /// A Unit of Measurement, this is, what is commonly referred to as a Unit.
    /// Examples include Meters, Feet, Seconds, Kilograms, ...
    /// </summary>
    public class UnitOfMeasurement
    {
        private readonly string _abbreviation;
        private Dimension _dimension;
        private double _multipleOfSi = 1.0;

        public UnitOfMeasurement(string abbreviation, Dimension dimension)
        {
            _abbreviation = abbreviation;
            _dimension = dimension;
        }

        public UnitOfMeasurement(string abbreviation, UnitOfMeasurement unit)
        {
            _abbreviation = abbreviation;
            _dimension = unit._dimension;
            _multipleOfSi = unit._multipleOfSi;
        }

        private UnitOfMeasurement(UnitOfMeasurement unit) : this(unit._abbreviation, unit)
        {
        }

        public string Abbreviation => _abbreviation;

        public Dimension Dimension
        {
            get
            {
                if (Dimensions.DerivedDimensions.TryGetValue(_dimension, out Dimension derived))
                    _dimension = derived;
                return _dimension;
            }
        }

        public double ValueInSiUnits => _multipleOfSi;

        private static void CheckDimensions(UnitOfMeasurement m1, UnitOfMeasurement m2)
        {
            var dimension1 = m1._dimension;
            var dimension2 = m2._dimension;
            if (!dimension1.Equals(dimension2))
            {
                throw new ArgumentException($"Dimensions do not match: {m1.Dimension.Name}, {m2.Dimension.Name} ");
            }
        }

        public double ValueInUnits(UnitOfMeasurement unit)
        {
            CheckDimensions(this, unit);

            return _multipleOfSi / unit._multipleOfSi;
        }

        public override string ToString()
        {
            return $"{Abbreviation} ({Dimension})";
        }

        public string ToString(string format = "", UnitOfMeasurement unit = null)
        {
            if (String.IsNullOrEmpty(format)) format = "{0:0.00} {1}";
            if (unit == null) unit = Dimension.DefaultUnit;

            if (unit == null)
            {
                return String.Format(format, ValueInSiUnits, this.ToSiUnitString());
            }
            else
            {
                return String.Format(format, ValueInUnits(unit), unit.Abbreviation);
            }
        }

        public string ToString(UnitOfMeasurement unit)
        {
            return ToString("", unit);
        }

        public string ToSiUnitString()
        {
            return Dimension.ToSiUnitString();
        }

        public static UnitOfMeasurement operator *(UnitOfMeasurement m1, UnitOfMeasurement m2)
        {
            return new UnitOfMeasurement(abbreviation: m1._abbreviation + " " + m2._abbreviation, unit: m2)
            {
                _multipleOfSi = m1._multipleOfSi * m2._multipleOfSi,
                _dimension = m1._dimension * m2._dimension,
            };
        }

        public static UnitOfMeasurement operator *(double n, UnitOfMeasurement unit)
        {
            var newUnit = new UnitOfMeasurement(abbreviation: "", unit: unit);
            newUnit._multipleOfSi *= n;
            return newUnit;
        }

        public static UnitOfMeasurement operator *(UnitOfMeasurement unit, double n)
        {
            return n * unit;
        }

        public static UnitOfMeasurement operator /(UnitOfMeasurement m1, UnitOfMeasurement m2)
        {
            return new UnitOfMeasurement($"{m1._abbreviation}/{m2._abbreviation}", m1 * m2.Inverse());
        }

        public static UnitOfMeasurement operator /(double n, UnitOfMeasurement unit)
        {
            return n * unit.Inverse();
        }

        public static UnitOfMeasurement operator /(UnitOfMeasurement unit, double n)
        {
            return (1.0 / n) * unit;
        }

        public static UnitOfMeasurement operator +(UnitOfMeasurement m1, UnitOfMeasurement m2)
        {
            CheckDimensions(m1, m2);
            return new UnitOfMeasurement(m1)
            {
                _multipleOfSi = m1._multipleOfSi + m2._multipleOfSi
            };
        }

        public static UnitOfMeasurement operator -(UnitOfMeasurement m1, UnitOfMeasurement m2)
        {
            CheckDimensions(m1, m2);
            return new UnitOfMeasurement(m1)
            {
                _multipleOfSi = m1._multipleOfSi - m2._multipleOfSi
            };
        }

        protected UnitOfMeasurement Inverse()
        {
            return new UnitOfMeasurement($"1/{_abbreviation}", this)
            {
                _multipleOfSi = 1.0 / _multipleOfSi,
                _dimension = _dimension.Inverse()
            };
        }
    }
}