using System.Collections.Generic;

namespace Durwella.Measurements
{
    /// <summary>
    /// A System of Measure such as SI or US Customary
    /// </summary>
    public interface IUnitSystem
    {
        /// <summary>
        /// Returns the set of <see cref="Dimension"/>s that are available in this System
        /// </summary>
        IEnumerable<Dimension> Dimensions { get; }

        /// <summary>
        /// Get the Unit System's standard <see cref="UnitOfMeasurement"/> 
        /// for the given <see cref="Dimension"/>.
        /// For example, returns kg for SI[Mass]
        /// </summary>
        UnitOfMeasurement this[Dimension dimension] { get; }

        /// <summary>
        /// Returns a set of available units in this System for the given Dimension
        /// </summary>
        IEnumerable<UnitOfMeasurement> GetUnits(Dimension dimension);
    }
}
