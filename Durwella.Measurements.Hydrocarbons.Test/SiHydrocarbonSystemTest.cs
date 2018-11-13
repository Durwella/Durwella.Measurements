using Durwella.Measurements.Testing;
using FluentAssertions;
using System.Linq;
using Xunit;
using static Durwella.Measurements.Hydrocarbons.HydrocarbonDimensions;
using static Durwella.Measurements.Hydrocarbons.HydrocarbonUnits;

namespace Durwella.Measurements.Hydrocarbons.Test
{
    public class SiHydrocarbonSystemTest
    {
        [Theory(DisplayName = "Consistent"), AutoMoqData]
        public void Consistent(SiHydrocarbonSystem subject)
        {
            subject.ShouldBeConsistent();
        }

        [Theory(DisplayName = "hours/plug"), AutoMoqData]
        public void HasPlugTime(SiHydrocarbonSystem subject)
        {
            var dimensions = subject.Dimensions;
            dimensions.Should().HaveCountGreaterThan(new SiSystem().Dimensions.Count());
            dimensions.Should().Contain(PlugTime);
            subject[PlugTime].Should().Be(HoursPerPlug);
        }
    }
}
