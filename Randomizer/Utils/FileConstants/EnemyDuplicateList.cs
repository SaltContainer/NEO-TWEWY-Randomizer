using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class EnemyDuplicateList
    {
        [JsonProperty("duplicates")]
        public IList<EnemyDuplicate> Duplicates { get; set; }
        [JsonProperty("forced-normal")]
        public IList<EnemyDuplicate> ForcedNormalDrops { get; set; }
        [JsonProperty("no-drops")]
        public IList<EnemyDuplicate> NoDrops { get; set; }
    }
}
