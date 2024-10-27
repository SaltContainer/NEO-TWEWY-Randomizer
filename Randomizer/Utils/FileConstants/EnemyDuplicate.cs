using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class EnemyDuplicate
    {
        [JsonProperty("id")]
        public EnemyData.Name Id { get; set; }
        [JsonProperty("duplicates")]
        public IList<EnemyData.Name> Duplicates { get; set; }
    }
}
