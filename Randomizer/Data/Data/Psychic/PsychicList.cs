using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class PsychicList
    {
        [JsonProperty("mTarget")]
        public IList<Psychic> Items { get; set; }
    }
}
