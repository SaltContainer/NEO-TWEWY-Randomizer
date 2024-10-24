using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class AttackComboSet
    {
        [JsonProperty("mId")]
        public int Id { get; set; }
        [JsonProperty("mAttack")]
        public IList<int> AttackList { get; set; }
    }
}
