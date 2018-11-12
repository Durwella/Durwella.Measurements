using FluentAssertions;

namespace Measurements
{
    static class SystemTesting
    {
        /// <summary>
        /// Enumerates all available units in all available dimensions checking for consistency.
        /// Checks that available units include standard units,
        /// and that Dimensions of units correspond to what was requested.
        /// </summary>
        public static void ShouldBeConsistent(this IUnitSystem system)
        {
            system.Dimensions.Should().NotBeEmpty();
            foreach (var dimension in system.Dimensions)
            {
                var standardUnit = system[dimension];
                var availableUnits = system.GetUnits(dimension);
                availableUnits.Should().Contain(standardUnit);
                foreach (var unit in availableUnits)
                {
                    unit.Dimension.Should().Be(dimension);
                }
            }
        }
    }
}
