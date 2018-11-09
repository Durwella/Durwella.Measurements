using FluentAssertions;
using Xunit;

namespace Measurements.Test
{
    public class DimensionTest
    {
        [Fact(DisplayName = "Length != Velocity")]
        public void SimpleNonMatchingDimensionTest()
        {
            Dimensions.Length.Should().NotBe(Dimensions.Velocity);
        }

        [Fact(DisplayName = "Length/Time = Velocity")]
        public void MoreComplicatedDimensionTest()
        {
            (Dimensions.Length / Dimensions.Time).Should().Be(Dimensions.Velocity);
        }

        [Fact(DisplayName = "B * A/B = A")]
        public void CancelDimensionInRational()
        {
            var baseDimensionA = new Dimension("Base Dimension A");
            baseDimensionA.NewSiUnit("Unit A");

            var baseDimensionB = new Dimension("Base Dimension B");
            baseDimensionB.NewSiUnit("Unit B");

            var derived = new Dimension("Derived Dimension", baseDimensionA / baseDimensionB);

            (derived * baseDimensionB).Should().Be(baseDimensionA);
        }
    }
}
