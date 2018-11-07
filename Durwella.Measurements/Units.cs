using Unit = Measurements.Measurement;

namespace Measurements
{
    public static class Units
    {
        // Length
        public static Unit Meters = Dimensions.Length.NewSIUnit("m");
        public static Unit Centimeters = new Unit("cm", Meters / 100);
        public static Unit Millimeters = new Unit("mm", Meters / 1000);
        public static Unit Kilometers = new Unit("k", 1000 * Meters);
        public static Unit Feet = new Unit("ft", 0.3048 * Meters);
        public static Unit Inches = new Unit("in", Feet / 12.0);
        public static Unit Yards = new Unit("yd", Feet * 3.0);
        public static Unit Miles = new Unit("mi", Feet * 5280.0);

        // Time
        public static Unit Seconds = Dimensions.Time.NewSIUnit("s");
        public static Unit Minutes = new Unit("min", Seconds * 60.0);
        public static Unit Hours = new Unit("hr", Minutes * 60.0);

        // Mass
        public static Unit Kilograms = Dimensions.Mass.NewSIUnit("kg");
        public static Unit Grams = new Unit("g", Kilograms / 1000.0);
        public static Unit PoundsMass = new Unit("lb", 0.45359237 * Kilograms);

        // Area
        public static Unit SquareMeters = Dimensions.Area.NewSIUnit("m2");
        public static Unit SquareInches = new Unit("in2", Inches * Inches);

        // Volume
        public static Unit CubicMeters = Dimensions.Area.NewSIUnit("m3");

        // Density
        public static Unit KilogramsPerCubicMeter = Dimensions.Density.NewSIUnit("kg/m3");

        // Frequency
        public static Unit Hertz = Dimensions.Mass.NewSIUnit("Hz");

        // Velocity
        public static Unit MetersPerSecond = Dimensions.Velocity.NewSIUnit("m/s");

        // Acceleration
        public static Unit MetersPerSecondSquared = Dimensions.Acceleration.NewSIUnit("m/s2");

        // Force
        public static Unit Newtons = Dimensions.Force.NewSIUnit("N");
        public static Unit PoundsForce = new Unit("lbf", 4.448222 * Newtons);

        // Pressure
        public static Unit Pascals = Dimensions.Pressure.NewSIUnit("Pa");
        public static Unit PoundsPerSquareInch = new Unit("psi", PoundsForce / SquareInches);
    }
}
