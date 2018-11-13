using FluentAssertions;
using Xunit;

namespace Durwella.Measurements.Hydrocarbons.Test
{
    public class UsHydrocarbonSystemTest
    {
        [Theory(DisplayName = "Consistent"), AutoMoqData]
        public void Consistent(UsHydrocarbonSystem subject)
        {
            subject.ShouldBeConsistent();
        }

        [Theory(DisplayName = "Volume (bbls)"), AutoMoqData]
        public void VolumeBarrels(UsHydrocarbonSystem subject)
        {
            var volumeUnits = subject.GetUnits(Dimensions.Volume);
            volumeUnits.Should()
                .HaveCountGreaterOrEqualTo(5)
                .And.Contain(Units.UsGallons)
                .And.Contain(HydrocarbonUnits.Barrels);
        }

        [Theory(DisplayName = "Flow (bbls/min)"), AutoMoqData]
        public void FlowBarrels(UsHydrocarbonSystem subject)
        {
            var volumeUnits = subject.GetUnits(Dimensions.VolumeFlowRate);
            volumeUnits.Should()
                .HaveCountGreaterOrEqualTo(3)
                .And.Contain(Units.GallonsPerMinute)
                .And.Contain(HydrocarbonUnits.BarrelsPerMinute)
                .And.Contain(HydrocarbonUnits.BarrelsPerDay);
        }

        [Fact(DisplayName = "bbls/day = .0066 m3/hr")]
        public void FluidBarrelsPerDayToSi()
        {
            HydrocarbonUnits.BarrelsPerDay.ValueInUnits(Units.CubicMetersPerHour)
                .Should().BeApproximately(.0066, 5e-5);
        }
    }
}
