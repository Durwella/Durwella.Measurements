using System.Collections.Generic;

namespace Durwella.Measurements
{
    /// <summary>
    /// A contract for getting a unique string Key for each <see cref="UnitOfMeasurement" /> and vice versa.
    /// This is similar to serialization, but we avoid possible problems w/ serializing units.
    /// For example, in the future we may change how we do conversion and store relative unit scales.
    /// The Key used in this scheme should be independent of how we implement units, 
    /// do conversion, build up derived abbreviations, or other things that might change.
    /// </summary>
    public interface IUnitKeyScheme
    {
        /// <summary>
        /// Returns a unique Key for the given <paramref name="unit"/> 
        /// that should be reliable for retrieving the <see cref="UnitOfMeasurement" /> in the future.
        /// </summary>
        string GetKey(UnitOfMeasurement unit);

        /// <summary>
        /// Returns the current <see cref="UnitOfMeasurement" /> implementation for the given <paramref name="key"/>.
        /// Throws a <see cref="KeyNotFoundException"/> if a <see cref="UnitOfMeasurement" /> has not been defined for the given <paramref name="key"/>.
        /// </summary>
        UnitOfMeasurement GetUnit(string key);
    }

    /*
     * 
     * IUnitKeyScheme IMPLEMENTATION NOTES
     * 
     * There are several surprising problems in creating a good persistent Key.
     * Here are some concerns w/ each Unit property.
     * 
     * Unit System:
     *      1. UnitOfMeasurement implementation is currently agnostic of ISystem. 
     *      2. Units of Time (e.g. Seconds) are used in both SI and USCS.
     * 
     * Abbreviation:
     *      I expect we will change how abbreviation is implemented. 
     *      For example, if we could go from s2 to s^2
     *      We really want the 'well-known' abbreviation like N, not a built-up abbreviation like kg m / s2
     * 
     * Scalar (_multipleOfSi):
     *      I want to be able to change the base 1.0 unit.
     *      Eventually we should support translation and scale (i.e. temperature)
     *      
     *  Full Name
     *      Eventually the full name of a unit should be localizable... So, it's not constant.
     *      Example: Meter, Metre, Metro, ... 
     *
     **/
}