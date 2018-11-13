using static Durwella.Measurements.Units;
using Unit = Durwella.Measurements.UnitOfMeasurement;

namespace Durwella.Measurements.Hydrocarbons
{
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
    }
}
