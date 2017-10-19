using FluentAssertions;
using System;
using Unit = Measurements.Measurement;
using Xunit;

namespace Measurements
{
    public class UnitTest
    {
        [Fact]
        public void SimpleToSIValue()
        {
            (1.0 * Units.Feet).ValueInSIUnits.Should().BeApproximately(0.3048, 0.0001);
        }

        [Fact]
        public void SimpleFromSIValue()
        {
            (1.0 * Units.Meters).ValueInUnits(Units.Feet).Should().BeApproximately(3.2808, 0.0001);
        }

        [Fact]
        public void CompoundUnitToSIValueTest()
        {
            var milesPerHour = new Unit("mph", Units.Miles / Units.Hours);

            (60.0 * milesPerHour).ValueInSIUnits.Should().BeApproximately(26.8224, 0.0001);
        }

        [Fact]
        public void CompoundUnitFromSIValueTest()
        {
            var metersPerSecond = Units.MetersPerSecond;
            var milesPerHour = new Unit("mph", Units.Miles / Units.Hours);

            (10.0 * metersPerSecond).ValueInUnits(milesPerHour).Should().BeApproximately(22.3694, 0.0001);
        }

        [Fact]
        public void HydrostaticPressureExample()
        {
            var g = 9.80665 * Units.MetersPerSecondSquared;
            var rho = 1000 * Units.KilogramsPerCubicMeter;
            var h = 10000 * Units.Feet;

            (rho * g * h).ValueInUnits(Units.PoundsPerSquareInch).Should().BeApproximately(4335.27504, 0.01);
        }

        [Fact]
        public void SimpleMatchingMeasurementTypeTest()
        {
            (1.0 * Units.Meters).Type.Should().Be(MeasurementTypes.Length);
        }

        [Fact]
        public void PressureMeasurementTypeTest()
        {
            var g = 9.80665 * Units.MetersPerSecondSquared;
            var rho = 1000 * Units.KilogramsPerCubicMeter;
            var h = 10000 * Units.Feet;

            (rho * g * h).Type.Should().Be(MeasurementTypes.Pressure);
        }

        [Fact]
        public void ToStringTest()
        {
            var g = 9.80665 * Units.MetersPerSecondSquared;
            var rho = 1000 * Units.KilogramsPerCubicMeter;
            var h = 10000 * Units.Feet;

            (1.23456 * Units.PoundsPerSquareInch).ToString("p = {0:0.000} {1}", Units.PoundsPerSquareInch).Should().Be("p = 1.235 psi");
        }

        [Fact]
        public void AdditionTest()
        {
            (1.0 * Units.MetersPerSecond + 1.0 * (Units.Miles / Units.Hours)).ValueInSIUnits.Should().BeApproximately(1.4470, 0.0001);
        }

        [Fact]
        public void SubtractionTest()
        {
            (1.0 * Units.MetersPerSecond - 1.0 * (Units.Miles / Units.Hours)).ValueInSIUnits.Should().BeApproximately(0.55296, 0.0001);
        }

        [Fact]
        public void DisallowConversionBetweenDifferentTypes()
        {
            var threw = false;
            try
            {
                var temp = (1.0 * Units.Meters).ValueInUnits(Units.MetersPerSecond);
            }
            catch (ArgumentException)
            {
                threw = true;
            }

            threw.Should().BeTrue();
        }

        [Fact]
        public void DisallowAddingDifferentTypes()
        {
            var threw = false;
            try
            {
                var temp = Units.Meters + Units.MetersPerSecond;
            }
            catch (ArgumentException)
            {
                threw = true;
            }
            threw.Should().BeTrue();
        }

        [Fact]
        public void DisallowSubtractingDifferentTypes()
        {
            var threw = true;
            try
            {
                var temp = Units.Meters - Units.MetersPerSecond;
            }
            catch (ArgumentException)
            {
                threw = true;
            }
            threw.Should().BeTrue();
        }

        [Fact]
        public void DocumentationExample()
        {
            var cookieCount = new MeasurementType("Cookie Count");
            var cookieRate = new MeasurementType("Cookie Rate", cookieCount / MeasurementTypes.Time);

            var cookies = cookieCount.NewSIUnit("cookies");
            var dozenCookies = new Unit("dz", 12 * cookies);
            var grossCookies = new Unit("gr", 144 * cookies);

            var workWeek = new Unit("work week", 40 * Units.Hours);

            var totalCookies = 12 * grossCookies;
            var cookiesRate =  totalCookies / workWeek;

            cookiesRate.ToString("{0:0.000} {1}").Should().Be("0.012 cookies/s");
            cookiesRate.ToString(cookies / Units.Minutes).Should().Be("0.72 cookies/min");
            cookiesRate.ToString("{0:0.0} {1}", dozenCookies / Units.Hours).Should().Be("3.6 dz/hr");
        }
    }
}
