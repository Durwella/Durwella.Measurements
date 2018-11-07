using FluentAssertions;
using Xunit;

namespace Measurements.Test
{
    public class DimensionTest
    {
        [Fact]
        public void RetrieveBaseDimensions()
        {
            var baseDimensionA = new Dimension("Base Dimension A");
            baseDimensionA.NewSIUnit("Unit A");

            var baseDimensionB = new Dimension("Base Dimension B");
            baseDimensionB.NewSIUnit("Unit B");

            var compoundDimension = new Dimension("Compound Dimension", baseDimensionA / baseDimensionB);

            (compoundDimension * baseDimensionB).Should().Be(baseDimensionA);
        }

        [Fact]
        public void SimpleNonMatchingDimensionTest()
        {
            Dimensions.Length.Should().NotBe(Dimensions.Velocity);
        }

        [Fact]
        public void MoreComplicatedDimensionTest()
        {
            (Dimensions.Length / Dimensions.Time).Should().Be(Dimensions.Velocity);
        }
    }
}
