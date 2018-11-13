using static Durwella.Measurements.Dimensions;

namespace Durwella.Measurements
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
