using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    static class Validator
    {
        public enum SettingsStringValidationResult
        {
            Valid,
            TooShort,
            NotHex,
            WrongVersion,
            Empty
        }

        public static int SettingsStringVersion = 0;
        public static int SettingsStringMinimumLength = 32;

        public static bool ValidateSeed(string seed)
        {
            int _;
            return int.TryParse(seed, out _);
        }

        public static SettingsStringValidationResult ValidateSettingsString(string settingsString)
        {
            if (settingsString.Any(c => !"0123456789abcdefABCDEF".Contains(c))) return SettingsStringValidationResult.NotHex;
            if (settingsString.Length <= 0) return SettingsStringValidationResult.Empty;

            int version = int.Parse(settingsString.Substring(settingsString.Length - 1, 1), System.Globalization.NumberStyles.HexNumber);
            if (version != SettingsStringVersion) return SettingsStringValidationResult.WrongVersion;

            return SettingsStringValidationResult.Valid;
        }
    }
}
