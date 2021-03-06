﻿using System;
using System.Collections.Generic;
using System.Linq;
using Unit = Durwella.Measurements.UnitOfMeasurement;

namespace Durwella.Measurements
{
    public class Dimension
    {
        private readonly string _name;
        private Unit _defaultUnit;
        private RationalCombination<Dimension> _baseDimensions = new RationalCombination<Dimension>(new List<Dimension>(), new List<Dimension>());

        public Dimension(string name)
        {
            _name = name;
            _baseDimensions.Numerator = new List<Dimension> { this };
        }

        public Dimension(string name, Dimension dimension)
        {
            this._name = name;
            //this._defaultUnit = dimension._defaultUnit;
            this._baseDimensions = dimension._baseDimensions;

            Dimensions.DerivedDimensions.Add(dimension, this);
        }

        private Dimension(RationalCombination<Dimension> combinable)
        {
            _baseDimensions = combinable;
            _defaultUnit = null;
        }


        public Unit NewSiUnit(string name)
        {
            _defaultUnit = new Unit(name, this);
            return _defaultUnit;
        }

        internal RationalCombination<Dimension> CombineWith(Dimension t2)
        {
            List<Dimension> numerator = this._baseDimensions.Numerator.Concat(t2._baseDimensions.Numerator).OrderBy(u => u.Name).ToList();
            List<Dimension> denominator = this._baseDimensions.Denominator.Concat(t2._baseDimensions.Denominator).OrderBy(u => u.Name).ToList();

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

        public string ToSiUnitString()
        {
            if (_baseDimensions.Numerator.Count() == 1 && _baseDimensions.Denominator.Count() == 0)
            {
                return _baseDimensions.Numerator.First().DefaultUnit.Abbreviation;
            }

            // TODO account for multiple appearances of a unit (e.g. s2 instead of s s)
            var numeratorStrings = _baseDimensions.Numerator.Select(t => t.ToSiUnitString());
            var denominatorStrings = _baseDimensions.Denominator.Select(t => t.ToSiUnitString());

            return String.Join(" ", numeratorStrings)
                + (numeratorStrings.Count() == 0 && denominatorStrings.Count() > 0 ? "1" : "")
                + (denominatorStrings.Count() > 0 ? "/" : "")
                + String.Join(" ", denominatorStrings);
        }

        public static Dimension operator *(Dimension dimension1, Dimension dimension2)
        {
            return new Dimension(dimension1.CombineWith(dimension2));
        }

        public static Dimension operator /(Dimension dimension1, Dimension dimension2)
        {
            return dimension1 * dimension2.Inverse();
        }

        public Dimension Inverse()
        {
            var newDimensions = new Dimension(this.Name); ;
            newDimensions._baseDimensions = new RationalCombination<Dimension>(this._baseDimensions.Denominator, this._baseDimensions.Numerator);
            return newDimensions;
        }

        public override string ToString() => Name;

        public override bool Equals(object obj)
        {
            if (!(obj is Dimension dimension)) return false;

            if (_baseDimensions.Numerator.Count() == 1 && _baseDimensions.Denominator.Count() == 0
                && dimension._baseDimensions.Numerator.Count() == 1 && dimension._baseDimensions.Denominator.Count() == 0)
            {
                return _baseDimensions.Numerator.First() == dimension._baseDimensions.Numerator.First();
            }
            return this._baseDimensions.Equals(dimension._baseDimensions);
        }

        public override int GetHashCode()
        {
            if (_baseDimensions.Numerator.Count() == 1 && _baseDimensions.Denominator.Count() == 0)
            {
                return _baseDimensions.Numerator.First().Name.GetHashCode();
            }
            else
            {
                return this._baseDimensions.GetHashCode();
            }
        }
    }
}
