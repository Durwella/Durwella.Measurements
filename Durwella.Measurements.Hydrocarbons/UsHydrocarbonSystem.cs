using System.Collections.Generic;
using System.Linq;
using static Durwella.Measurements.Dimensions;
using static Durwella.Measurements.Hydrocarbons.HydrocarbonUnits;

namespace Durwella.Measurements.Hydrocarbons
{
    public class UsHydrocarbonSystem : UscSystem
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

        private readonly UnitOfMeasurement[] _volumeConcentrationUnits = new[]
        {
            GallonsPerTenBarrels
        };

        public override IEnumerable<Dimension> Dimensions =>
            base.Dimensions.Concat(new[] { HydrocarbonDimensions.PlugTime });

        public override UnitOfMeasurement this[Dimension dimension]
        {
            get
            {
                if (dimension == HydrocarbonDimensions.PlugTime)
                    return HoursPerPlug;
                return base[dimension];
            }
        }

        public override IEnumerable<UnitOfMeasurement> GetUnits(Dimension dimension)
        {
            if (dimension == HydrocarbonDimensions.PlugTime)
                return new[] { HoursPerPlug };
            var units = base.GetUnits(dimension);
            if (dimension == Volume)
                units = units.Concat(_volumeUnits);
            if (dimension == VolumeFlowRate)
                units = units.Concat(_flowUnits);
            if (dimension == VolumeConcentration)
                units = units.Concat(_volumeConcentrationUnits);
            return units;
        }
    }
}
