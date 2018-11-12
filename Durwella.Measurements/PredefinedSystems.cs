using static Measurements.Dimensions;

namespace Measurements
{
    internal static class PredefinedSystems
    {
        internal static readonly Dimension[] Dimensions = new[]
        {
            // Basic
            Length,
            Mass,
            Time,

            // Derived
            Area,
            Volume,
            Density,
            Velocity,
            Acceleration,
            Force,
            Pressure,
        };
    }
}
