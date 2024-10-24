using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class AttackHitList
    {
        [JsonProperty("mTarget")]
        public IList<AttackHit> Items { get; set; }
    }
}
