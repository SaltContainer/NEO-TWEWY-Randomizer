using System;
using System.Collections.Generic;
using System.Linq;

namespace NEO_TWEWY_Randomizer
{
    public static class SourceLinks
    {
        private static string gitHubLink = "https://github.com/SaltContainer/NEO-TWEWY-Randomizer";

        public static string GetGitHubLink()
        {
            return gitHubLink;
        }

        public static string GetSmallVersion()
        {
            Version version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            List<int> significantNumber = new List<int>() { version.Revision, version.Build, version.Minor, version.Major };
            while (significantNumber.Count > 0 && significantNumber[0] == 0)
            {
                significantNumber.RemoveAt(0);
            }
            significantNumber.Reverse();
            return string.Join(".", significantNumber.Select(i => i.ToString()));
        }

        public static string GetFullVersion()
        {
            return System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
        }
    }
}
