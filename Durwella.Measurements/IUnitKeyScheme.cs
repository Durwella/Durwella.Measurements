namespace Measurements
{
    /// <summary>
    /// A contract for getting a unique string Key for each <see cref="UnitOfMeasurement" /> and vice versa.
    /// This is similar to serialization, but we avoid possible problems w/ serializing units.
    /// For example, in the future we may change how we do conversion and store relative unit scales.
    /// The Key used in this scheme should be independent of how we implement units or do conversion.
    /// </summary>
    public interface IUnitKeyScheme
    {
        /// <summary>
        /// Returns a unique Key for this Unit that should be reliable for retrieving the Unit in the future.
        /// </summary>
        string GetKey(UnitOfMeasurement unit);

        /// <summary>
        /// Returns the current Unit implementation for the given key.
        /// Throws an exception if a Unit has not been defined for the given key.
        /// </summary>
        UnitOfMeasurement GetUnit(string key);
    }
}