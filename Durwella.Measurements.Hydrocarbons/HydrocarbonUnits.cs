using static Durwella.Measurements.Dimensions;
using static Durwella.Measurements.Units;
using Unit = Durwella.Measurements.UnitOfMeasurement;

namespace Durwella.Measurements.Hydrocarbons
{
    public static class HydrocarbonDimensions
    {
        public static Dimension PlugCount = new Dimension("Plug Count");

        public static Dimension PlugTime = new Dimension("Plug Time", Time / PlugCount);
    }

    public static class HydrocarbonUnits
    {
        /// <summary>
        /// Barrels of Oil (bbl) defined as 42 U.S. Gallons
        /// </summary>
        public static Unit Barrels = new Unit("bbl", 42 * Units.UsGallons);

        /// <summary>
        /// Thousand Barrels of Oil (Mbbl)
        /// </summary>
        public static Unit ThousandBarrels = new Unit("Mbbl", 1_000 * Barrels);

        /// <summary>
        /// Million Barrels of Oil (MMbbl)
        /// </summary>
        public static Unit MillionBarrels = new Unit("MMbbl", 1_000_000 * Barrels);

        /// <summary>
        /// Billion Barrels of Oil (Gbbl)
        /// </summary>
        public static Unit BillionBarrels = new Unit("Gbbl", 1_000_000_000 * Barrels);

        /// <summary>
        /// Barrels per Minute of fluid flow rate (bpm)
        /// </summary>
        public static Unit BarrelsPerMinute = new Unit("bpm", Barrels / Minutes);

        /// <summary>
        /// Barrels of Oil per Day of fluid flow rate (BOPD)
        /// </summary>
        public static Unit BarrelsPerDay = new Unit("BOPD", Barrels / Days);

        public static Unit MillionCubicFeetPerDay = new Unit("MMSCFD", 1_000_000 * CubicFeet / Days);

        public static Unit ThousandCubicFeetPerDay = new Unit("MSCFD", 1_000 * CubicFeet / Days);


        public static Unit Plugs = HydrocarbonDimensions.PlugCount.NewSiUnit("plug");

        public static Unit HoursPerPlug = new Unit("hrs/plug", Hours / Plugs);

        public static Unit GallonsPerTenBarrels = new Unit("gal/10bbl", UsGallons / (10 * Barrels));

        public static Unit PoundsPerGallon = new Unit("ppg", PoundsMass / UsGallons);

        public static Unit PartsPerMillion = new Unit("ppm", 1_000_000 * VolumeRatio);



    }
}
