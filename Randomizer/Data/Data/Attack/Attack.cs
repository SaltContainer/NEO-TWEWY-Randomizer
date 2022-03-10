using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class Attack
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
