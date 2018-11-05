using FluentAssertions;
using Xunit;

namespace Measurements
{
    public class SiSystemTest
    {
        // https://en.wikipedia.org/wiki/Metric_system#Base_units

        [Theory(DisplayName = "SI:Length"), AutoMoqData]
        public void SiLength(SiSystem subject)
        {
            subject[MeasurementTypes.Length].Should().Be(Units.Meters);
            subject[MeasurementTypes.Length].Type.Should().Be(MeasurementTypes.Length);
        }

        [Theory(DisplayName = "SI:Mass"), AutoMoqData]
        public void SiMass(SiSystem subject)
        {
            subject[MeasurementTypes.Mass].Should().Be(Units.Kilograms);
            subject[MeasurementTypes.Mass].Type.Should().Be(MeasurementTypes.Mass);
        }

        [Theory(DisplayName = "SI:Time"), AutoMoqData]
        public void SiTime(SiSystem subject)
        {
            subject[MeasurementTypes.Time].Should().Be(Units.Seconds);
            subject[MeasurementTypes.Time].Type.Should().Be(MeasurementTypes.Time);
        }

        //[Theory(DisplayName = "SI:Electromagnetism"), AutoMoqData]
        //public void SiElectro(SiSystem subject)
        //{
        //    subject[MeasurementTypes.Electromagnetism].Should().Be(Units.Amperes);
        //}

        //[Theory(DisplayName = "SI:Temperature"), AutoMoqData]
        //public void SiTemperature(SiSystem subject)
        //{
        //    subject[MeasurementTypes.Temperature].Should().Be(Units.Kelvin);
        //}

        //[Theory(DisplayName = "SI:LuminousIntensity"), AutoMoqData]
        //public void SiLuminousIntensity(SiSystem subject)
        //{
        //    subject[MeasurementTypes.LuminousIntensity].Should().Be(Units.Candelas);
        //}

        //[Theory(DisplayName = "SI:Quantity"), AutoMoqData]
        //public void SiQuantity(SiSystem subject)
        //{
        //    subject[MeasurementTypes.Quantity].Should().Be(Units.Moles);
        //}
    }
}
