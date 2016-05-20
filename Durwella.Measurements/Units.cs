using Unit = Measurements.Measurement;

namespace Measurements
{
    public static class Units
    {
        // Length
        public static Unit Meters = MeasurementTypes.Length.NewSIUnit("m");
        public static Unit Millimeters = new Unit("mm", 1000 * Meters);
        public static Unit Centimeters = new Unit("cm", 1000 * Meters);
        public static Unit Kilometers = new Unit("ft", 1000 * Meters);
        public static Unit Feet = new Unit("ft", 0.3048 * Meters);
        public static Unit Inches = new Unit("in", Feet / 12.0);
        public static Unit Yards = new Unit("yd", Feet * 3.0);
        public static Unit Miles = new Unit("mi", Feet * 5280.0);
 
        // Time
        public static Unit Seconds = MeasurementTypes.Time.NewSIUnit("s");
        public static Unit Minutes = new Unit("min", Seconds * 60.0);
        public static Unit Hours = new Unit("hr", Minutes * 60.0);

        // Mass
        public static Unit Kilograms = MeasurementTypes.Mass.NewSIUnit("kg");
        public static Unit Grams = new Unit("g", Kilograms / 1000.0);
       
        // Area
        public static Unit SquareMeters = MeasurementTypes.Area.NewSIUnit("m2");
        public static Unit SquareInches = new Unit("in2", Inches * Inches);

        // Volume
        public static Unit CubicMeters = MeasurementTypes.Area.NewSIUnit("m3");
        
        // Density
        public static Unit KilogramsPerCubicMeter = MeasurementTypes.Density.NewSIUnit("kg/m3");

        // Frequency
        public static Unit Hertz = MeasurementTypes.Mass.NewSIUnit("Hz");

        // Velocity
        public static Unit MetersPerSecond = MeasurementTypes.Velocity.NewSIUnit("m/s");

        // Acceleration
        public static Unit MetersPerSecondSquared = MeasurementTypes.Acceleration.NewSIUnit("m/s2");

        // Force
        public static Unit Newtons = MeasurementTypes.Force.NewSIUnit("N");
        public static Unit Pounds = new Unit("lb", 4.44822 * Newtons);
        
        // Pressure
        public static Unit Pascals = MeasurementTypes.Pressure.NewSIUnit("Pa");
        public static Unit PoundsPerSquareInch = new Unit("psi", Pounds / SquareInches);
    }
}
