using FluentAssertions;
using Xunit;

namespace Durwella.Measurements
{
    public class UnitsTest
    {
        [Fact(DisplayName = "km")]
        public void Kilometers()
        {
            var fiveK = 5.0 * Units.Kilometers;
            fiveK.ToString(Units.Kilometers).Should().Be("5.00 km");
            fiveK.ValueInUnits(Units.Meters).Should().Be(5000);
            //(1.0 * Units.Kilometers).Should().Be(1000.0 * Units.Meters);
        }

        [Fact(DisplayName = "cm")]
        public void Centimeters()
        {
            var cm = Units.Centimeters;
            (200 * cm).ValueInUnits(Units.Meters).Should().Be(2.0);
            (2.54 * cm).ValueInUnits(Units.Inches).Should().BeApproximately(1.0, 1e-9);
            (5 * cm).ToString(cm).Should().Be("5.00 cm");
        }

        [Fact(DisplayName = "mm")]
        public void Millimeters()
        {
            var mm = Units.Millimeters;
            (3000 * mm).ValueInUnits(Units.Meters).Should().Be(3.0);
            (19 * mm).ValueInUnits(Units.Inches).Should().BeApproximately(0.75, 0.002);
            (12 * mm).ToString(mm).Should().Be("12.00 mm");
        }
    }
}
