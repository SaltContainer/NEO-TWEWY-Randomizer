using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    static class SourceLinks
    {
        private static string gitHubLink = "https://github.com/SaltContainer/NEO-TWEWY-Randomizer";

        public static string GetGitHubLink()
        {
            return gitHubLink;
        }

        public static string GetVersion()
        {
            return System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
        }
    }
}
