using System.Collections.Generic;
using Unit = Measurements.UnitOfMeasurement;

namespace Measurements
{
    /// <summary>
    /// Commonly defined Units of Measurement
    /// </summary>
    public static class Units
    {
        internal static List<Unit> PredefinedUnits = new List<Unit>(30);

        #region Length

        public static Unit Meters = Add(Dimensions.Length.NewSiUnit("m"));
        public static Unit Centimeters = Add(new Unit("cm", Meters / 100));
        public static Unit Millimeters = Add(new Unit("mm", Meters / 1000));
        public static Unit Kilometers = Add(new Unit("km", 1000 * Meters));
        public static Unit Feet = Add(new Unit("ft", 0.3048 * Meters));
        public static Unit Inches = Add(new Unit("in", Feet / 12.0));
        public static Unit Yards = Add(new Unit("yd", Feet * 3.0));
        public static Unit Miles = Add(new Unit("mi", Feet * 5280.0));

        #endregion
        #region Time

        public static Unit Seconds = Add(Dimensions.Time.NewSiUnit("s"));
        public static Unit Minutes = Add(new Unit("min", Seconds * 60.0));
        public static Unit Hours = Add(new Unit("hr", Minutes * 60.0));
        internal static Unit[] OfTime = new[] { Seconds, Minutes, Hours };

        #endregion
        #region Mass

        public static Unit Kilograms = Add(Dimensions.Mass.NewSiUnit("kg"));
        public static Unit Grams = Add(new Unit("g", Kilograms / 1000.0));

        /// <summary>
        /// The pound or pound-mass is a unit of mass used in the imperial, United States customary and other systems of measurement. Various definitions have been used; the most common today is the international avoirdupois pound, which is legally defined as exactly 0.45359237 kilograms, and which is divided into 16 avoirdupois ounces.
        /// </summary>
        public static Unit PoundsMass = Add(new Unit("lb", 0.45359237 * Kilograms));

        /// <summary>
        /// The short ton is a unit of weight equal to 2,000 pounds (907.18474 kg).
        /// </summary>
        public static Unit ShortTons = Add(new Unit("ton", 2000 * PoundsMass));

        /// <summary>
        /// The common avoirdupois ounce (approximately 28.3 g) is ​1/16 of a common avoirdupois pound; this is the United States customary and British imperial ounce.
        /// </summary>
        public static Unit Ounces = Add(new Unit("oz", PoundsMass / 16));

        /// <summary>
        /// A slug is defined as the mass that is accelerated by 1 ft/s2 when a force of one pound (lbf) is exerted on it.
        /// </summary>
        public static Unit Slugs = Add(new Unit("slug", 32.1740 * PoundsMass));

        #endregion
        #region Area

        public static Unit SquareMeters = Add(Dimensions.Area.NewSiUnit("m2"));
        public static Unit SquareFeet = Add(new Unit("ft2", Feet * Feet));
        public static Unit SquareInches = Add(new Unit("in2", Inches * Inches));

        #endregion
        #region Volume

        public static Unit CubicMeters = Add(Dimensions.Volume.NewSiUnit("m3"));
        public static Unit CubicFeet = Add(new Unit("ft3", Feet * Feet * Feet));
        public static Unit CubicInches = Add(new Unit("in3", Inches * Inches * Inches));

        #endregion
        #region Density

        public static Unit KilogramsPerCubicMeter = Add(Dimensions.Density.NewSiUnit("kg/m3"));
        public static Unit SlugsPerCubicFoot = Add(new Unit("slug/ft3", Slugs / CubicFeet));

        #endregion
        #region Frequency

        public static Unit Hertz = Add(Dimensions.Frequency.NewSiUnit("Hz"));

        #endregion
        #region Velocity

        public static Unit MetersPerSecond = Add(Dimensions.Velocity.NewSiUnit("m/s"));
        public static Unit KilometersPerHour = Add(new Unit("kph", Kilometers / Hours));
        public static Unit FeetPerSecond = Add(new Unit("ft/s", Feet / Seconds));
        public static Unit FeetPerMinute = Add(new Unit("ft/min", Feet / Minutes));
        public static Unit FeetPerHour = Add(new Unit("ft/hr", Feet / Hours));
        public static Unit MilesPerHour = Add(new Unit("mph", Miles / Hours));

        #endregion
        #region Acceleration

        public static Unit MetersPerSecondSquared = Add(Dimensions.Acceleration.NewSiUnit("m/s2"));
        public static Unit FeetPerSecondSquared = Add(new Unit("ft/s2", Feet / (Seconds * Seconds)));

        #endregion
        #region Force

        public static Unit Newtons = Add(Dimensions.Force.NewSiUnit("N"));
        public static Unit PoundsForce = Add(new Unit("lbf", 4.448222 * Newtons));

        #endregion
        #region Pressure

        public static Unit Pascals = Add(Dimensions.Pressure.NewSiUnit("Pa"));
        public static Unit PoundsPerSquareInch = Add(new Unit("psi", PoundsForce / SquareInches));

        #endregion

        #region private

        private static Unit Add(Unit unit)
        {
            PredefinedUnits.Add(unit);
            return unit;
        }

        #endregion
    }
}
