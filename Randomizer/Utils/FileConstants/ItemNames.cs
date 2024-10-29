using Newtonsoft.Json;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    public class ItemNames
    {
        [JsonProperty("pins")]
        public IList<NameAssociation> Pins { get; set; }
        [JsonProperty("pin-items")]
        public IList<NameAssociation> PinItems { get; set; }
        [JsonProperty("yen-pins")]
        public IList<NameAssociation> YenPins { get; set; }
        [JsonProperty("gem-pins")]
        public IList<NameAssociation> GemPins { get; set; }
        [JsonProperty("limited-pins")]
        public IList<NameAssociation> LimitedPins { get; set; }
        [JsonProperty("enemies")]
        public IList<NameAssociation> Enemies { get; set; }
        [JsonProperty("pigs")]
        public IList<NameAssociation> Pigs { get; set; }
        [JsonProperty("growth-classes")]
        public IList<NameAssociation> GrowthRates { get; set; }
        [JsonProperty("brands")]
        public IList<NameAssociation> Brands { get; set; }
        [JsonProperty("affinities")]
        public IList<NameAssociation> Affinities { get; set; }
        [JsonProperty("pin-abilities")]
        public IList<NameAssociation> PinAbilities { get; set; }
        [JsonProperty("characters")]
        public IList<NameAssociation> Characters { get; set; }
        [JsonProperty("rando-pin-images")]
        public IList<NameAssociation> RandoPinImages { get; set; }
        [JsonProperty("fp")]
        public IList<NameAssociation> FP { get; set; }
        [JsonProperty("reports")]
        public IList<NameAssociation> SecretReports{ get; set; }
        [JsonProperty("scenario-pins")]
        public IList<NameAssociation> StoryPins { get; set; }
        [JsonProperty("scenario-limited-pins")]
        public IList<NameAssociation> StoryLimitedPins { get; set; }
        [JsonProperty("scenario-yen")]
        public IList<NameAssociation> StoryYen { get; set; }
        [JsonProperty("scenario-gems")]
        public IList<NameAssociation> StoryGems { get; set; }
        [JsonProperty("scenario-fp")]
        public IList<NameAssociation> StoryFP { get; set; }
        [JsonProperty("scenario-reports")]
        public IList<NameAssociation> StoryReports { get; set; }
        [JsonProperty("scenario-yen-2nd")]
        public IList<NameAssociation> StoryYen2nd { get; set; }
        [JsonProperty("skills")]
        public IList<NameAssociation> Skills { get; set; }
        [JsonProperty("skill-tree-slots")]
        public IList<NameAssociation> SkillSlots { get; set; }
        [JsonProperty("threads")]
        public IList<NameAssociation> Threads { get; set; }
    }
}
