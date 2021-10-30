using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class EnemyDuplicateList
    {
        [JsonProperty("duplicates")]
        public IList<EnemyDuplicate> Duplicates { get; set; }
        [JsonProperty("forced-normal")]
        public IList<EnemyDuplicate> ForcedNormalDrops { get; set; }
        [JsonProperty("no-drops")]
        public IList<EnemyDuplicate> NoDrops { get; set; }
    }
}
