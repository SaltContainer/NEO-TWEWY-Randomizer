using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class BadgeList
    {
        [JsonProperty("mTarget")]
        public IList<Badge> Items { get; set; }
    }
}
