using System.Collections.Generic;
using System.Linq;
using static Durwella.Measurements.Dimensions;
using static Durwella.Measurements.Hydrocarbons.HydrocarbonUnits;

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

        private readonly UnitOfMeasurement[] _flowUnits = new[]
        {
            BarrelsPerMinute,
            BarrelsPerDay
        };

        public override IEnumerable<UnitOfMeasurement> GetUnits(Dimension dimension)
        {
            var units = base.GetUnits(dimension);
            if (dimension == Volume)
                units = units.Concat(_volumeUnits);
            if (dimension == VolumeFlowRate)
                units = units.Concat(_flowUnits);
            return units;
        }
    }
}
