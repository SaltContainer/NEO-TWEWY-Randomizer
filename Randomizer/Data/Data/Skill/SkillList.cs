using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class SkillList
    {
        [JsonProperty("mTarget")]
        public IList<Skill> Items { get; set; }
    }
}
