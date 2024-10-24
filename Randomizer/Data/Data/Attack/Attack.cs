using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class Attack
    {
        [JsonProperty("mId")]
        public int Id { get; set; }
        [JsonProperty("mHit")]
        public IList<int> HitList { get; set; }
        [JsonProperty("mEffect")]
        public IList<int> EffectList { get; set; }
        [JsonProperty("mEffectAttach")]
        public IList<int> EffectAttachList { get; set; }
        [JsonProperty("mEffectParent")]
        public IList<string> EffectParentList { get; set; }
        [JsonProperty("mEffectPlayOption")]
        public IList<int> EffectPlayOptionList { get; set; }
    }
}
