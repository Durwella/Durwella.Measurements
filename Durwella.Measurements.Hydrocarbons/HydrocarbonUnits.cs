using Unit = Durwella.Measurements.UnitOfMeasurement;

namespace Durwella.Measurements.Hydrocarbons
{
    public static class HydrocarbonUnits
    {
        public static Unit Barrels = new Unit("bbl", 42 * Units.UsGallons);
        public static Unit ThousandBarrels = new Unit("Mbbl", 1_000 * Barrels);
        public static Unit MillionBarrels = new Unit("MMbbl", 1_000_000 * Barrels);
        public static Unit BillionBarrels = new Unit("Gbbl", 1_000_000_000 * Barrels);
    }
}
