using System;

namespace Measurements
{
    /// <summary>
    /// A Unit of Measurement, this is, what is commonly referred to as a Unit.
    /// Examples include Meters, Feet, Seconds, Kilograms, ...
    /// </summary>
    public class UnitOfMeasurement
    {
        private string _name;
        private Dimension _dimension;
        private double _multipleOfSI = 1.0;

        public UnitOfMeasurement(string name, Dimension dimension)
        {
            _name = name;
            _dimension = dimension;
        }

        public UnitOfMeasurement(string name, UnitOfMeasurement unit)
        {
            _name = name;
            _dimension = unit._dimension;
            _multipleOfSI = unit._multipleOfSI;
        }

        private UnitOfMeasurement(UnitOfMeasurement unit) : this(unit._name, unit)
        {
        }

        public string Name { get { return _name; } }

        public Dimension Dimension
        {
            get
            {
                Dimension compound = null;
                if (Dimensions.CompoundDimensions.TryGetValue(_dimension, out compound))
                {
                    _dimension = compound;
                    return compound;
                }
                else
                {
                    return _dimension;
                }
            }
        }

        public double ValueInSIUnits
        {
            get
            {
                return _multipleOfSI;
            }
        }

        private static void checkDimensions(UnitOfMeasurement m1, UnitOfMeasurement m2)
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
            checkDimensions(this, unit);

            return _multipleOfSI / unit._multipleOfSI;
        }

        public override string ToString()
        {
            return $"{Name} ({Dimension})";
        }

        public string ToString(string format = "", UnitOfMeasurement unit = null)
        {
            if (String.IsNullOrEmpty(format)) format = "{0:0.00} {1}";
            if (unit == null) unit = Dimension.DefaultUnit;

            if (unit == null)
            {
                return String.Format(format, ValueInSIUnits, this.ToSIUnitString());
            }
            else
            {
                return String.Format(format, ValueInUnits(unit), unit.Name);
            }
        }

        public string ToString(UnitOfMeasurement unit)
        {
            return ToString("", unit);
        }

        public string ToSIUnitString()
        {
            return Dimension.ToSIUnitString();
        }

        public static UnitOfMeasurement operator *(UnitOfMeasurement m1, UnitOfMeasurement m2)
        {
            var newMeasurement = new UnitOfMeasurement(m2);
            newMeasurement._multipleOfSI = m1._multipleOfSI * m2._multipleOfSI;
            newMeasurement._dimension = m1._dimension * m2._dimension;
            newMeasurement._name = m1._name + " " + m2._name;

            return newMeasurement;
        }

        public static UnitOfMeasurement operator *(double n, UnitOfMeasurement meeas)
        {
            var newUnit = new UnitOfMeasurement(meeas);
            newUnit._multipleOfSI *= n;
            newUnit._name = "";

            return newUnit;
        }

        public static UnitOfMeasurement operator *(UnitOfMeasurement unit, double n)
        {
            return n * unit;
        }

        public static UnitOfMeasurement operator /(UnitOfMeasurement m1, UnitOfMeasurement m2)
        {
            var newUnit = m1 * m2.Inverse();
            newUnit._name = m1._name + "/" + m2._name;

            return newUnit;
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
            checkDimensions(m1, m2);

            var newUnit = new UnitOfMeasurement(m1);
            newUnit._multipleOfSI = m1._multipleOfSI + m2._multipleOfSI;

            return newUnit;
        }
        public static UnitOfMeasurement operator -(UnitOfMeasurement m1, UnitOfMeasurement m2)
        {
            checkDimensions(m1, m2);

            var newUnit = new UnitOfMeasurement(m1);
            newUnit._multipleOfSI = m1._multipleOfSI - m2._multipleOfSI;

            return newUnit;
        }


        protected UnitOfMeasurement Inverse()
        {
            var newUnit = new UnitOfMeasurement(this);

            newUnit._name = "1/(" + newUnit._name + ")";
            newUnit._multipleOfSI = 1.0 / this._multipleOfSI;
            newUnit._dimension = this._dimension.Inverse();

            return newUnit;
        }
    }
}