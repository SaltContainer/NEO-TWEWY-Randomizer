using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class SettingsStringVersionList
    {
        [JsonProperty("versions")]
        public IList<SettingsStringVersion> Items { get; set; }
    }
}
