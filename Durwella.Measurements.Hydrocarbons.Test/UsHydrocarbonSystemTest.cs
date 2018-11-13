using FluentAssertions;
using Measurements;
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

        [Theory(DisplayName = "Barrels"), AutoMoqData]
        public void VolumeBarrels(UsHydrocarbonSystem subject)
        {
            var volumeUnits = subject.GetUnits(Dimensions.Volume);
            volumeUnits.Should()
                .HaveCountGreaterOrEqualTo(5)
                .And.Contain(Units.UsGallons)
                .And.Contain(HydrocarbonUnits.Barrels);
        }
    }
}
