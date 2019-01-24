using System.Collections.Generic;
using System.Linq;
using static Durwella.Measurements.Hydrocarbons.HydrocarbonUnits;
using static Durwella.Measurements.Dimensions;

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
        private readonly UnitOfMeasurement[] _volumeConcentrationUnits = new[]
        {
            PartsPerMillion //not technically a volume concentration?
        };

        public override IEnumerable<UnitOfMeasurement> GetUnits(Dimension dimension)
        {
            if (dimension == HydrocarbonDimensions.PlugTime)
                return new[] { HoursPerPlug };
            var units = base.GetUnits(dimension);
          
            if (dimension == VolumeConcentration)
                units = units.Concat(_volumeConcentrationUnits);
            
            return units;
        }
    }
}
