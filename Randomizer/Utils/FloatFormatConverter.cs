using Newtonsoft.Json;
using System;
using System.Globalization;

namespace NEO_TWEWY_Randomizer
{
    public class FloatFormatConverter : JsonConverter
    {
        public int decimals;

        public FloatFormatConverter(int decimals)
        {
            this.decimals = decimals;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(float);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(string.Format(CultureInfo.InvariantCulture, "{0:F" + decimals.ToString() + "}", value));
        }

        public override bool CanRead => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
