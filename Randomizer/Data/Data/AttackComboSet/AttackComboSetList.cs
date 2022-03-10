using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class AttackComboSetList
    {
        [JsonProperty("mTarget")]
        public IList<AttackComboSet> Items { get; set; }
    }
}
