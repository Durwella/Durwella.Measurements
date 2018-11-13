using Measurements;
using System.Collections.Generic;
using System.Linq;
using static Durwella.Measurements.Hydrocarbons.HydrocarbonUnits;
using static Measurements.Dimensions;

namespace Durwella.Measurements.Hydrocarbons
{
    public class UsHydrocarbonSystem : UscSystem, IUnitSystem
    {
        private readonly UnitOfMeasurement[] _volumeUnits = new[]
        {
            Barrels,
            ThousandBarrels,
            MillionBarrels,
            BillionBarrels
        };

        public override IEnumerable<UnitOfMeasurement> GetUnits(Dimension dimension)
        {
            var units = base.GetUnits(dimension);
            if (dimension == Volume)
                units = units.Concat(_volumeUnits);
            return units;
        }
    }
}
