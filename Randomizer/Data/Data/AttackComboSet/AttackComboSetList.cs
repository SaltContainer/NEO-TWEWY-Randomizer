using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class AttackComboSetList
    {
        [JsonProperty("mTarget")]
        public IList<AttackComboSet> Items { get; set; }
    }
}
