namespace Measurements
{
    /// <summary>
    /// A System of Measure such as SI or US Customary
    /// </summary>
    public interface IUnitSystem
    {
        /// <summary>
        /// Get the Unit System's standard <see cref="UnitOfMeasurement"/> 
        /// for the given <see cref="Dimension"/>.
        /// For example, returns kg for SI[Mass]
        /// </summary>
        UnitOfMeasurement this[Dimension dimension] { get; }
    }
}
