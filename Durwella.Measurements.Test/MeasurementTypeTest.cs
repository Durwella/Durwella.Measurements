using FluentAssertions;
using NUnit.Framework;

namespace Measurements.Test
{
    public class MeasurementTypeTest
    {
        [Test]
        public void RetrieveBaseTypes()
        {
            var baseTypeA = new MeasurementType("Base Type A");
            baseTypeA.NewSIUnit("Unit A");

            var baseTypeB = new MeasurementType("Base Type B");
            baseTypeB.NewSIUnit("Unit B");

            var compoundType = new MeasurementType("Compound Type", baseTypeA / baseTypeB);
            
            (compoundType * baseTypeB).Should().Equals(baseTypeA);
        }

        [Test]
        public void SimpleNonMatchingMeasurementTypeTest()
        {
            MeasurementTypes.Length.Should().NotBe(MeasurementTypes.Velocity);
        }

        [Test]
        public void MoreComplicatedMeasurementTypeTest()
        {
            (MeasurementTypes.Length / MeasurementTypes.Time).Should().Be(MeasurementTypes.Velocity);
        }
    }
}
