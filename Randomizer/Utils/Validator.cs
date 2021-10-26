using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    static class Validator
    {
        public static bool ValidateSeed(string seed)
        {
            int _;
            return int.TryParse(seed, out _);
        }

        public static bool ValidateSettingsString(string settingsString)
        {
            if (settingsString.Length > 16) return false;
            if (settingsString.Any(c => !"0123456789abcdefABCDEF".Contains(c))) return false;
            return true;
        }
    }
}
