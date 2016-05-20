using System;
using System.Collections.Generic;

namespace Measurements
{
    public class Measurement
    {
        private string _name;
        private MeasurementType _type;
        private double _multipleOfSI = 1.0;

        public Measurement(string name, MeasurementType type)
        {
            _name = name;
            _type = type;
        }

        public Measurement(string name, Measurement unit)
        {
            _name = name;

            _type = unit._type;
            _multipleOfSI = unit._multipleOfSI;
        }

        private Measurement(Measurement unit): this(unit._name, unit)
        {
        }

        public string Name { get { return _name; } }

        public MeasurementType Type
        {
            get
            {
                MeasurementType compound = null;
                if (MeasurementTypes.CompoundTypes.TryGetValue(_type, out compound)) {
                    _type = compound;
                    return compound;
                } else
                {
                    return _type;
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

        private static void checkTypes(Measurement m1, Measurement m2)
        {
            var type1 = m1._type;
            var type2 = m2._type;
            if (!type1.Equals(type2))
            {
                throw new ArgumentException($"Types do not match: {m1.Type.Name}, {m2.Type.Name} ");
            }
        }

        public double ValueInUnits(Measurement unit)
        {
            checkTypes(this, unit);
            
            return _multipleOfSI / unit._multipleOfSI;
        }

        public string ToString(string format = "", Measurement unit = null)
        {
            if (String.IsNullOrEmpty(format)) format = "{0:0.00} {1}";
            if (unit == null) unit = Type.DefaultUnit;

            if (unit == null)
            {
                return String.Format(format, ValueInSIUnits, this.ToSIUnitString());
            } else
            {
                return String.Format(format, ValueInUnits(unit), unit.Name);
            }
        }

        public string ToString(Measurement unit)
        {
            return ToString("", unit);
        }

        public string ToSIUnitString()
        {
            return Type.ToSIUnitString();
        }

        public static Measurement operator *(Measurement m1, Measurement m2)
        {
            var newMeasurement = new Measurement(m2);
            newMeasurement._multipleOfSI = m1._multipleOfSI * m2._multipleOfSI;
            newMeasurement._type = m1._type * m2._type;
            newMeasurement._name = m1._name + " " + m2._name;

            return newMeasurement;
        }

        public static Measurement operator *(double n, Measurement meeas)
        {
            var newUnit = new Measurement(meeas);
            newUnit._multipleOfSI *= n;
            newUnit._name = "";

            return newUnit;
        }

        public static Measurement operator *(Measurement meas, double n)
        {
            return n * meas;
        }

        public static Measurement operator /(Measurement m1, Measurement m2)
        {
            var newUnit = m1 * m2.Inverse();
            newUnit._name = m1._name + "/" + m2._name;

            return newUnit;
        }

        public static Measurement operator /(double n, Measurement meas)
        {
            return n * meas.Inverse();
        }

        public static Measurement operator /(Measurement meas, double n)
        {
            return (1.0/ n) * meas;
        }

        public static Measurement operator +(Measurement m1, Measurement m2)
        {
            checkTypes(m1, m2);

            var newUnit = new Measurement(m1);
            newUnit._multipleOfSI = m1._multipleOfSI + m2._multipleOfSI;

            return newUnit;
        }
        public static Measurement operator -(Measurement m1, Measurement m2)
        {
            checkTypes(m1, m2);

            var newUnit = new Measurement(m1);
            newUnit._multipleOfSI = m1._multipleOfSI - m2._multipleOfSI;

            return newUnit;
        }


        protected Measurement Inverse()
        {
            var newUnit = new Measurement(this);

            newUnit._name = "1/(" + newUnit._name + ")";
            newUnit._multipleOfSI = 1.0 / this._multipleOfSI;
            newUnit._type = this._type.Inverse();

            return newUnit;
        }
    }
}