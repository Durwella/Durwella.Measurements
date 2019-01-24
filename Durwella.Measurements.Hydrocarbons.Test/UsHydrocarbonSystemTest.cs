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
        [Theory(DisplayName = "ppmshouldbeaconcetration"), AutoMoqData]
        public void PpmShouldBeAConcentration(UsHydrocarbonSystem subject)
        {
            var concentrationUnits = subject.GetUnits(Dimensions.VolumeConcentration);
            concentrationUnits.Should().Contain(c => c.Abbreviation == "ppm");
        }

        [Theory(DisplayName = "MMSCFD to ft/3"), AutoMoqData]
        public void MMSCFDToFt3ps(UsHydrocarbonSystem subject)
        {
            var mmcfdUnit = subject.GetUnits(Dimensions.VolumeFlowRate)
                .Single(u => u.Abbreviation == "MMSCFD");

            var cubicFeetDayUnit = subject.GetUnits(Dimensions.VolumeFlowRate)
                .Single(u => u.Abbreviation == "ft3/s");

            mmcfdUnit.ValueInUnits(cubicFeetDayUnit).Should().BeApproximately(11.57407, 0.001);
        }

        [Theory(DisplayName = "ppg to kg/m3"), AutoMoqData]
        public void ppgTokgm3(UsHydrocarbonSystem subject)
        {
            var ppg = subject.GetUnits(Dimensions.Density)
                .Single(u => u.Abbreviation == "ppg");

            var kgm3 = Units.KilogramsPerCubicMeter;

            ppg.ValueInUnits(kgm3).Should().BeApproximately(119.82642731689666, 0.001);
        }


    }
}
