using FluentAssertions;
using Xunit;

namespace Measurements.Test
{
    public class DimensionTest
    {
        [Fact]
        public void RetrieveBaseTypes()
        {
            var baseTypeA = new Dimension("Base Type A");
            baseTypeA.NewSIUnit("Unit A");

            var baseTypeB = new Dimension("Base Type B");
            baseTypeB.NewSIUnit("Unit B");

            var compoundType = new Dimension("Compound Type", baseTypeA / baseTypeB);
            
            (compoundType * baseTypeB).Should().Be(baseTypeA);
        }

        [Fact]
        public void SimpleNonMatchingMeasurementTypeTest()
        {
            MeasurementTypes.Length.Should().NotBe(MeasurementTypes.Velocity);
        }

        [Fact]
        public void MoreComplicatedMeasurementTypeTest()
        {
            (MeasurementTypes.Length / MeasurementTypes.Time).Should().Be(MeasurementTypes.Velocity);
        }
    }
}
