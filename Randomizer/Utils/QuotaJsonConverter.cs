using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer.Randomizer.Utils
{
    class QuotaJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Quota).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jobject = JObject.Load(reader);

            string realType = (string)jobject["type"];

            Quota quota;
            if (realType == FileConstants.BrandQuotaSubType) quota = new BrandQuota();
            else if (realType == FileConstants.ItemQuotaSubType) quota = new ItemQuota();
            else if (realType == FileConstants.OwnPinQuotaSubType) quota = new OwnBadgeQuota();
            else if (realType == FileConstants.NoiseQuotaSubType) quota = new NoiseQuota();
            else if (realType == FileConstants.BossNoiseQuotaSubType) quota = new BossNoiseQuota();
            else if (realType == FileConstants.RelationshipQuotaSubType) quota = new RelationshipQuota();
            else if (realType == FileConstants.TrophyQuotaSubType) quota = new TrophyQuota();
            else quota = new ReductionQuota();

            serializer.Populate(jobject.CreateReader(), quota);

            return quota;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
