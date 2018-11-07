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
            subject[Dimensions.Length].Should().Be(Units.Feet);
            subject[Dimensions.Length].Dimension.Should().Be(Dimensions.Length);
        }

        [Theory(DisplayName = "USCS:Mass"), AutoMoqData]
        public void UscMass(UscSystem subject)
        {
            subject[Dimensions.Mass].Should().Be(Units.PoundsMass);
            subject[Dimensions.Mass].Dimension.Should().Be(Dimensions.Mass);
        }

        [Theory(DisplayName = "USCS:Time"), AutoMoqData]
        public void UscTime(UscSystem subject)
        {
            subject[Dimensions.Time].Should().Be(Units.Seconds);
            subject[Dimensions.Time].Dimension.Should().Be(Dimensions.Time);
        }
    }
}
