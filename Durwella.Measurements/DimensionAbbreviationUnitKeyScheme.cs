using System;
using System.Collections.Generic;
using System.Linq;

namespace Measurements
{
    /// <summary>
    /// Only works with the predefined <see cref="Units"/>!
    /// Uses a Key format of Dimension:Abbreviation with a magic prefix of DA1. 
    /// For example: "DA1:Length:m", "DA1:Mass:lb"
    /// </summary>
    public class DimensionAbbreviationUnitKeyScheme : IUnitKeyScheme
    {
        private const string MagicPrefix = "DA1";
        private const char Separator = ':';

        public string GetKey(UnitOfMeasurement unit)
        {
            if (unit is null)
                throw new ArgumentNullException(nameof(unit));
            return string.Join(Separator.ToString(), MagicPrefix, unit.Dimension.Name, unit.Abbreviation);
        }

        /// <summary>
        /// Searches predefined Units for a matching abbreviation and dimension from the key
        /// </summary>
        public UnitOfMeasurement GetUnit(string key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));
            var tokens = key.Split(Separator);
            var magicPrefix = tokens.FirstOrDefault();
            if (magicPrefix != MagicPrefix || tokens.Length != 3)
                throw new FormatException($"The key '{key}' was not in the expected format.");
            var dimension = tokens[1];
            var abbreviation = tokens[2];
            var unit = Units.PredefinedUnits.SingleOrDefault(
                u => u.Abbreviation == abbreviation && u.Dimension.Name == dimension);
            if (unit == null)
                throw new KeyNotFoundException($"Unit for key '{key}' was not found in  Predefined Units.");
            return unit;
        }
    }
}