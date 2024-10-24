using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class PigDataList
    {
        [JsonProperty("mTarget")]
        public IList<PigData> Items { get; set; }
    }
}
