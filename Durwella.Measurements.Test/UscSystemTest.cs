using Durwella.Measurements.Testing;
using FluentAssertions;
using Xunit;

namespace Durwella.Measurements
{
    public class UscSystemTest
    {
        // https://en.wikipedia.org/wiki/United_States_customary_units

        [Theory(DisplayName = "USCS:Consistent"), AutoMoqData]
        public void Consistent(UscSystem subject)
        {
            subject.ShouldBeConsistent();
        }

        [Theory(DisplayName = "USCS:Length"), AutoMoqData]
        public void UscLength(UscSystem subject)
        {
            subject[Dimensions.Length].Should().Be(Units.Feet);
        }

        [Theory(DisplayName = "USCS:Mass"), AutoMoqData]
        public void UscMass(UscSystem subject)
        {
            subject[Dimensions.Mass].Should().Be(Units.PoundsMass);
        }

        [Theory(DisplayName = "USCS:Time"), AutoMoqData]
        public void UscTime(UscSystem subject)
        {
            subject[Dimensions.Time].Should().Be(Units.Seconds);
        }

        [Theory(DisplayName = "USCS:Pressure"), AutoMoqData]
        public void UscPressure(UscSystem subject)
        {
            subject[Dimensions.Pressure].Should().Be(Units.PoundsPerSquareInch);
        }

        [Theory(DisplayName = "USCS:Force"), AutoMoqData]
        public void Force(UscSystem subject)
        {
            subject[Dimensions.Force].Should().Be(Units.PoundsForce);
        }

        #region GetUnits() enumeration

        [Theory(DisplayName = "USCS:Length Units"), AutoMoqData]
        public void EnumerateUnitsForLength(UscSystem subject)
        {
            subject.GetUnits(Dimensions.Length).Should().BeEquivalentTo(
                Units.Feet, Units.Inches, Units.Yards, Units.Miles);
        }

        [Theory(DisplayName = "USCS:Mass Units"), AutoMoqData]
        public void EnumerateUnitsForMass(UscSystem subject)
        {
            subject.GetUnits(Dimensions.Mass).Should().BeEquivalentTo(
                Units.PoundsMass, Units.Ounces, Units.Slugs, Units.ShortTons);
        }

        [Theory(DisplayName = "USCS:Time Units"), AutoMoqData]
        public void EnumerateUnitsForTime(UscSystem subject)
        {
            subject.GetUnits(Dimensions.Time).Should().BeEquivalentTo(
                Units.Days, Units.Hours, Units.Minutes, Units.Seconds);
        }

        [Fact(DisplayName = "USCS:SI Definitions")]
        public void MeetStandardSiDefinitions()
        {
            Units.Ounces.ValueInUnits(Units.Grams).Should().BeApproximately(28.3, 0.05);
            Units.UsGallons.ValueInUnits(Units.Liters).Should().BeApproximately(3.785411784, 1e-9);
        }

        #endregion
    }
}
