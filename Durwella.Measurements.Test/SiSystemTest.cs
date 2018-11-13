using Durwella.Measurements.Testing;
using FluentAssertions;
using Xunit;

namespace Durwella.Measurements
{
    public class SiSystemTest
    {
        // https://en.wikipedia.org/wiki/Metric_system#Base_units

        [Theory(DisplayName = "SI:Consistent"), AutoMoqData]
        public void Consistent(SiSystem subject)
        {
            subject.ShouldBeConsistent();
        }

        [Theory(DisplayName = "SI:Length"), AutoMoqData]
        public void SiLength(SiSystem subject)
        {
            subject[Dimensions.Length].Should().Be(Units.Meters);
        }

        [Theory(DisplayName = "SI:Mass"), AutoMoqData]
        public void SiMass(SiSystem subject)
        {
            subject[Dimensions.Mass].Should().Be(Units.Kilograms);
        }

        [Theory(DisplayName = "SI:Time"), AutoMoqData]
        public void SiTime(SiSystem subject)
        {
            subject[Dimensions.Time].Should().Be(Units.Seconds);
        }

        //[Theory(DisplayName = "SI:Electromagnetism"), AutoMoqData]
        //public void SiElectro(SiSystem subject)
        //{
        //    subject[Dimensions.Electromagnetism].Should().Be(Units.Amperes);
        //}

        //[Theory(DisplayName = "SI:Temperature"), AutoMoqData]
        //public void SiTemperature(SiSystem subject)
        //{
        //    subject[Dimensions.Temperature].Should().Be(Units.Kelvin);
        //}

        //[Theory(DisplayName = "SI:LuminousIntensity"), AutoMoqData]
        //public void SiLuminousIntensity(SiSystem subject)
        //{
        //    subject[Dimensions.LuminousIntensity].Should().Be(Units.Candelas);
        //}

        //[Theory(DisplayName = "SI:Quantity"), AutoMoqData]
        //public void SiQuantity(SiSystem subject)
        //{
        //    subject[Dimensions.Quantity].Should().Be(Units.Moles);
        //}

        [Theory(DisplayName = "SI:Pressure"), AutoMoqData]
        public void SiPressure(SiSystem subject)
        {
            subject[Dimensions.Pressure].Should().Be(Units.Pascals);
        }

        [Theory(DisplayName = "SI:Force"), AutoMoqData]
        public void Force(SiSystem subject)
        {
            subject[Dimensions.Force].Should().Be(Units.Newtons);
        }

        #region GetUnits() enumeration

        [Theory(DisplayName = "SI:Length Units"), AutoMoqData]
        public void EnumerateUnitsForLength(SiSystem subject)
        {
            subject.GetUnits(Dimensions.Length).Should().BeEquivalentTo(
                Units.Millimeters, Units.Centimeters, Units.Meters, Units.Kilometers);
        }

        [Theory(DisplayName = "SI:Mass Units"), AutoMoqData]
        public void EnumerateUnitsForMass(SiSystem subject)
        {
            subject.GetUnits(Dimensions.Mass).Should().BeEquivalentTo(
                Units.Grams, Units.Kilograms);
        }

        [Theory(DisplayName = "SI:Time Units"), AutoMoqData]
        public void EnumerateUnitsForTime(SiSystem subject)
        {
            subject.GetUnits(Dimensions.Time).Should().BeEquivalentTo(
                Units.Days, Units.Hours, Units.Minutes, Units.Seconds);
        }

        #endregion
    }
}
