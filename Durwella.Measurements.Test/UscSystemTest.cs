using FluentAssertions;
using Xunit;

namespace Measurements
{
    public class UscSystemTest
    {
        // https://en.wikipedia.org/wiki/United_States_customary_units

        [Theory(DisplayName = "USCS:Length"), AutoMoqData]
        public void UscLength(UscSystem subject)
        {
            subject[MeasurementTypes.Length].Should().Be(Units.Feet);
            subject[MeasurementTypes.Length].Type.Should().Be(MeasurementTypes.Length);
        }

        [Theory(DisplayName = "USCS:Mass"), AutoMoqData]
        public void UscMass(UscSystem subject)
        {
            subject[MeasurementTypes.Mass].Should().Be(Units.PoundsMass);
            subject[MeasurementTypes.Mass].Type.Should().Be(MeasurementTypes.Mass);
        }

        [Theory(DisplayName = "USCS:Time"), AutoMoqData]
        public void UscTime(UscSystem subject)
        {
            subject[MeasurementTypes.Time].Should().Be(Units.Seconds);
            subject[MeasurementTypes.Time].Type.Should().Be(MeasurementTypes.Time);
        }
    }
}
