namespace Measurements
{
    /// <summary>
    /// A System of Measure such as SI or US Customary
    /// </summary>
    public interface IUnitSystem
    {
        /// <summary>
        /// Get the Unit System's standard <see cref="Measurement"/> 
        /// for the given <see cref="MeasurementType"/>.
        /// For example, returns kg for SI[Mass]
        /// </summary>
        Measurement this[MeasurementType measurementType] { get; }
    }

    /// <summary>
    /// The International System of Units (SI) or Metric System.
    /// </summary>
    public class SiSystem : IUnitSystem
    {
        public Measurement this[MeasurementType measurementType] =>
            Units.Meters;
    }

    /// <summary>
    /// The United States Customary System of Units (USCS or USC)
    /// </summary>
    public class UscSystem : IUnitSystem
    {
        public Measurement this[MeasurementType measurementType] => throw new System.NotImplementedException();
    }
}
