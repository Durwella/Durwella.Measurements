using System.Collections.Generic;
using System.Linq;

namespace Durwella.Measurements
{
    internal class RationalCombination<T>
    {
        public IEnumerable<T> Numerator = new List<T>();
        public IEnumerable<T> Denominator = new List<T>();

        public RationalCombination(IEnumerable<T> numerator, IEnumerable<T> denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public override bool Equals(object obj)
        {
            // TODO: Improve testing of this
            var other = obj as RationalCombination<T>;
            if (other == null) return false;

            return Numerator.SequenceEqual(other.Numerator) 
                && Denominator.SequenceEqual(other.Denominator);
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
