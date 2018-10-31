using System;
using System.Collections.Generic;
using System.Linq;
using Unit = Measurements.Measurement;

namespace Measurements
{
    public class MeasurementType
    {
        private string _name;
        private Unit _defaultUnit;

        public MeasurementType(string name)
        {
            _name = name;
            _baseTypes.Numerator = new List<MeasurementType> { this };
        }

        public MeasurementType(string name, MeasurementType type)
        {
            this._name = name;
            //this._defaultUnit = type._defaultUnit;
            this._baseTypes = type._baseTypes;

            MeasurementTypes.CompoundTypes.Add(type, this);
        }

        private MeasurementType(Combinable<MeasurementType> combinable)
        {
            _baseTypes = combinable;
            _defaultUnit = null;
        }


        internal Combinable<MeasurementType> _baseTypes = new Combinable<MeasurementType>(new List<MeasurementType>(), new List<MeasurementType>());

        public Unit NewSIUnit(string name)
        {
            _defaultUnit = new Unit(name, this);
            return _defaultUnit;
        }

        internal Combinable<MeasurementType> CombineWith(MeasurementType t2)
        {
            List<MeasurementType> numerator = this._baseTypes.Numerator.Concat(t2._baseTypes.Numerator).OrderBy(u => u.Name).ToList();
            List<MeasurementType> denominator = this._baseTypes.Denominator.Concat(t2._baseTypes.Denominator).OrderBy(u => u.Name).ToList();

            var i = numerator.Count() - 1;
            var j = denominator.Count() - 1;
            while (i >= 0 && j >= 0)
            {
                while (denominator[j].Name.CompareTo(numerator[i].Name) > 0)
                {
                    j--;
                    if (j < 0) break;
                }
                if (j < 0) break;

                if (denominator[j].Name.Equals(numerator[i].Name))
                {
                    numerator.RemoveAt(i);
                    denominator.RemoveAt(j);
                    j--;
                }

                i--;
            }

            return new Combinable<MeasurementType>(numerator, denominator);
        }

        public Unit DefaultUnit { get { return _defaultUnit; } }

        public string Name { get { return _name; } }

        public string ToSIUnitString()
        {
            if (_baseTypes.Numerator.Count() == 1 && _baseTypes.Denominator.Count() == 0)
            {
                return _baseTypes.Numerator.First().DefaultUnit.Name;
            }

            // TODO account for multiple appearances of a unit (e.g. s2 instead of s s)
            var numeratorStrings = _baseTypes.Numerator.Select(t => t.ToSIUnitString());
            var denominatorStrings = _baseTypes.Denominator.Select(t => t.ToSIUnitString());

            return String.Join(" ", numeratorStrings)
                + (numeratorStrings.Count() == 0 && denominatorStrings.Count() > 0 ? "1" : "")
                + (denominatorStrings.Count() > 0 ? "/" : "")
                + String.Join(" ", denominatorStrings);
        }

        public static MeasurementType operator *(MeasurementType type1, MeasurementType type2)
        {
            return new MeasurementType(type1.CombineWith(type2));
        }

        public static MeasurementType operator /(MeasurementType type1, MeasurementType type2)
        {
            return type1 * type2.Inverse();
        }

        public MeasurementType Inverse()
        {
            var newType = new MeasurementType(this.Name); ;
            newType._baseTypes = new Combinable<MeasurementType>(this._baseTypes.Denominator, this._baseTypes.Numerator);

            return newType;
        }

        public override bool Equals(object obj)
        {
            var type = obj as MeasurementType;
            if (type == null) return false;

            if (_baseTypes.Numerator.Count() == 1 && _baseTypes.Denominator.Count() == 0
                && type._baseTypes.Numerator.Count() == 1 && type._baseTypes.Denominator.Count() == 0)
            {
                return _baseTypes.Numerator.First() == type._baseTypes.Numerator.First();
            }
            return this._baseTypes.Equals(type._baseTypes);
        }

        public override int GetHashCode()
        {
            if (_baseTypes.Numerator.Count() == 1 && _baseTypes.Denominator.Count() == 0)
            {
                return _baseTypes.Numerator.First().Name.GetHashCode();
            }
            else
            {
                return this._baseTypes.GetHashCode();
            }
        }
    }

    internal class Combinable<T>
    {
        public IEnumerable<T> Numerator = new List<T>();
        public IEnumerable<T> Denominator = new List<T>();

        public Combinable(IEnumerable<T> numerator, IEnumerable<T> denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public override bool Equals(object obj)
        {
            // TODO: Improve testing of this
            var other = obj as Combinable<T>;
            if (other == null) return false;

            return this.Numerator.SequenceEqual(other.Numerator) && this.Denominator.SequenceEqual(other.Denominator);
        }

        public override int GetHashCode()
        {
            var hash = 17;
            foreach (var c in Numerator)
            {
                hash = 23 * hash + c.GetHashCode();
            }
            foreach (var c in Denominator)
            {
                hash = 23 * hash + c.GetHashCode();
            }
            return hash;
        }
    };
}
