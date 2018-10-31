using FluentAssertions;
using Xunit;

namespace Measurements.Test
{
    public class MeasurementTypeTest
    {
        [Fact]
        public void RetrieveBaseTypes()
        {
            var baseTypeA = new MeasurementType("Base Type A");
            baseTypeA.NewSIUnit("Unit A");

            var baseTypeB = new MeasurementType("Base Type B");
            baseTypeB.NewSIUnit("Unit B");

            var compoundType = new MeasurementType("Compound Type", baseTypeA / baseTypeB);
            
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
