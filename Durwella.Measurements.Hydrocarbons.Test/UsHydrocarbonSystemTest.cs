using Durwella.Measurements.Testing;
using FluentAssertions;
using System.Linq;
using Xunit;
using static Durwella.Measurements.Hydrocarbons.HydrocarbonDimensions;
using static Durwella.Measurements.Hydrocarbons.HydrocarbonUnits;

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
                .And.Contain(Barrels);
        }

        [Theory(DisplayName = "Flow (bbls/min)"), AutoMoqData]
        public void FlowBarrels(UsHydrocarbonSystem subject)
        {
            var volumeUnits = subject.GetUnits(Dimensions.VolumeFlowRate);
            volumeUnits.Should()
                .HaveCountGreaterOrEqualTo(3)
                .And.Contain(Units.GallonsPerMinute)
                .And.Contain(BarrelsPerMinute)
                .And.Contain(BarrelsPerDay);
        }

        [Theory(DisplayName = "hours/plug"), AutoMoqData]
        public void HasPlugTime(UsHydrocarbonSystem subject)
        {
            var dimensions = subject.Dimensions;
            dimensions.Should().HaveCountGreaterThan(new UscSystem().Dimensions.Count());
            dimensions.Should().Contain(PlugTime);
            subject[PlugTime].Should().Be(HoursPerPlug);
        }

        [Fact(DisplayName = "bbls/day = .0066 m3/hr")]
        public void FluidBarrelsPerDayToSi()
        {
            BarrelsPerDay.ValueInUnits(Units.CubicMetersPerHour)
                .Should().BeApproximately(.0066, 5e-5);
        }

        [Theory(DisplayName = "gal/10bbl"), AutoMoqData]
        public void VolumeConcentrationGallons(UsHydrocarbonSystem subject)
        {
            subject.GetUnits(Dimensions.VolumeConcentration)
                .Should().HaveCountGreaterThan(2)
                .And.Contain(GallonsPerTenBarrels);
            GallonsPerTenBarrels.Dimension
                .Should().Be(Dimensions.VolumeConcentration);
        }
    }
}
