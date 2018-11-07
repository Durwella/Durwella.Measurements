using System;
using System.Collections.Generic;
using System.Linq;
using Unit = Measurements.Measurement;

namespace Measurements
{
    public class Dimension
    {
        private string _name;
        private Unit _defaultUnit;

        public Dimension(string name)
        {
            _name = name;
            _baseTypes.Numerator = new List<Dimension> { this };
        }

        public Dimension(string name, Dimension type)
        {
            this._name = name;
            //this._defaultUnit = type._defaultUnit;
            this._baseTypes = type._baseTypes;

            MeasurementTypes.CompoundTypes.Add(type, this);
        }

        private Dimension(RationalCombination<Dimension> combinable)
        {
            _baseTypes = combinable;
            _defaultUnit = null;
        }


        internal RationalCombination<Dimension> _baseTypes = new RationalCombination<Dimension>(new List<Dimension>(), new List<Dimension>());

        public Unit NewSIUnit(string name)
        {
            _defaultUnit = new Unit(name, this);
            return _defaultUnit;
        }

        internal RationalCombination<Dimension> CombineWith(Dimension t2)
        {
            List<Dimension> numerator = this._baseTypes.Numerator.Concat(t2._baseTypes.Numerator).OrderBy(u => u.Name).ToList();
            List<Dimension> denominator = this._baseTypes.Denominator.Concat(t2._baseTypes.Denominator).OrderBy(u => u.Name).ToList();

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

            return new RationalCombination<Dimension>(numerator, denominator);
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

        public static Dimension operator *(Dimension type1, Dimension type2)
        {
            return new Dimension(type1.CombineWith(type2));
        }

        public static Dimension operator /(Dimension type1, Dimension type2)
        {
            return type1 * type2.Inverse();
        }

        public Dimension Inverse()
        {
            var newType = new Dimension(this.Name); ;
            newType._baseTypes = new RationalCombination<Dimension>(this._baseTypes.Denominator, this._baseTypes.Numerator);

            return newType;
        }

        public override string ToString() => Name;

        public override bool Equals(object obj)
        {
            var type = obj as Dimension;
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
}
