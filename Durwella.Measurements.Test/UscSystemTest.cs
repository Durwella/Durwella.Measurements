﻿using FluentAssertions;
using Xunit;

namespace Measurements
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
            subject[Dimensions.Length].Dimension.Should().Be(Dimensions.Length);
        }

        [Theory(DisplayName = "USCS:Mass"), AutoMoqData]
        public void UscMass(UscSystem subject)
        {
            subject[Dimensions.Mass].Should().Be(Units.PoundsMass);
            subject[Dimensions.Mass].Dimension.Should().Be(Dimensions.Mass);
        }

        [Theory(DisplayName = "USCS:Time"), AutoMoqData]
        public void UscTime(UscSystem subject)
        {
            subject[Dimensions.Time].Should().Be(Units.Seconds);
            subject[Dimensions.Time].Dimension.Should().Be(Dimensions.Time);
        }

        [Theory(DisplayName = "USCS:Pressure"), AutoMoqData]
        public void UscPressure(UscSystem subject)
        {
            subject[Dimensions.Pressure].Should().Be(Units.PoundsPerSquareInch);
            subject[Dimensions.Pressure].Dimension.Should().Be(Dimensions.Pressure);
        }

        [Theory(DisplayName = "USCS:Force"), AutoMoqData]
        public void Force(UscSystem subject)
        {
            subject[Dimensions.Force].Should().Be(Units.PoundsForce);
            subject[Dimensions.Force].Dimension.Should().Be(Dimensions.Force);
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
                Units.Hours, Units.Minutes, Units.Seconds);
        }

        [Fact(DisplayName = "USCS:SI Definitions")]
        public void MeetStandardSiDefinitions()
        {
            Units.Ounces.ValueInUnits(Units.Grams).Should().BeApproximately(28.3, 0.05);
        }

        #endregion
    }
}
