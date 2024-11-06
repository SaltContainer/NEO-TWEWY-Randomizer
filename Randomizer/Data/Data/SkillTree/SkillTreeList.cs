using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class SkillTreeList
    {
        [JsonProperty("mTarget")]
        public IList<SkillTree> Items { get; set; }
    }
}
