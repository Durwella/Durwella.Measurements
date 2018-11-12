using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;
using static Measurements.Units;

namespace Measurements.Test
{
    public class DimensionAbbreviationKeySchemeTest
    {
        [Theory(DisplayName = "Keys"), AutoMoqData]
        public void Keys(DimensionAbbreviationUnitKeyScheme subject)
        {
            subject.GetKey(Meters).Should().Be("DA1:Length:m");
            subject.GetKey(MetersPerSecondSquared).Should().Be("DA1:Acceleration:m/s2");
            subject.GetKey(Grams).Should().Be("DA1:Mass:g");
            subject.GetKey(Ounces).Should().Be("DA1:Mass:oz");
        }

        [Theory(DisplayName = "Round-Trip"), AutoMoqData]
        public void RoundTripKnownUnits(DimensionAbbreviationUnitKeyScheme subject)
        {
            var units = new[]
            {
                Meters, Centimeters, Feet, Inches,
                Seconds, Minutes, Hours,
                Grams, PoundsMass,
                PoundsForce, Newtons,
                SquareMeters, SquareInches,
                CubicMeters,
                Pascals, PoundsPerSquareInch
            };
            foreach (var unit in units)
            {
                var key = subject.GetKey(unit);
                subject.GetUnit(key).Should().Be(unit);
            }
        }

        [Theory(DisplayName = "Exceptions"), AutoMoqData]
        public void Exceptions(DimensionAbbreviationUnitKeyScheme subject)
        {
            // Mismatched dimension:
            ShouldThrow<KeyNotFoundException>(() => subject.GetUnit("DA1:Mass:m"));
            // Not a predefined unit:
            var derivedKey = subject.GetKey(Meters * Seconds);
            ShouldThrow<KeyNotFoundException>(() => subject.GetUnit(derivedKey));
            // Wrong format:
            ShouldThrow<FormatException>(() => subject.GetUnit(""));
            ShouldThrow<FormatException>(() => subject.GetUnit("DA2:Length:m"));
            ShouldThrow<FormatException>(() => subject.GetUnit("DA1:Mass"));
            ShouldThrow<FormatException>(() => subject.GetUnit("DA1:Mass:kg:"));
        }

        void ShouldThrow<T>(Action act) where T : Exception =>
            act.Should().Throw<T>();
    }
}
