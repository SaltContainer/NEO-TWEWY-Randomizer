using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class AttackComboSet
    {
        [JsonProperty("mId")]
        public int Id { get; set; }
        [JsonProperty("mAttack")]
        public IList<int> AttackList { get; set; }
    }
}
