using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    class EnemyReport
    {
        [JsonProperty("mId")]
        public int Id { get; set; }
        [JsonProperty("mSortIndex")]
        public int SortIndex { get; set; }
        [JsonProperty("mCharacter")]
        public int CharacterId { get; set; }
        [JsonProperty("mGroupCharacter")]
        public IList<int> GroupCharacter { get; set; }
        [JsonProperty("mEnemydata")]
        public int EnemyDataId { get; set; }
        [JsonProperty("mIcon")]
        public string Icon { get; set; }
        [JsonProperty("mSymbolType")]
        public int SymbolType { get; set; }
        [JsonProperty("mName")]
        public string Name { get; set; }
        [JsonProperty("mInfo")]
        public string Info { get; set; }
        [JsonProperty("mIsBoss")]
        public bool IsBoss { get; set; }
        [JsonProperty("mWeak")]
        public IList<int> Weaknesses { get; set; }
        [JsonProperty("mNoiseImagePath")]
        public string NoiseImagePath { get; set; }
    }
}
