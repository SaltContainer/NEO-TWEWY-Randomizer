using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class AttackList
    {
        [JsonProperty("mTarget")]
        public IList<Attack> Items { get; set; }
    }
}
