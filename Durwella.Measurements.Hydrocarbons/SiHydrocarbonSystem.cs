using System.Collections.Generic;
using System.Linq;
using static Durwella.Measurements.Hydrocarbons.HydrocarbonUnits;

namespace Durwella.Measurements.Hydrocarbons
{
    public class SiHydrocarbonSystem : SiSystem
    {
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
            return base.GetUnits(dimension);
        }
    }
}
