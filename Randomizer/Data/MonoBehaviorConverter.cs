using AssetsTools.NET;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO_TWEWY_Randomizer
{
    static class MonoBehaviorConverter
    {
        public static JObject ConvertFromBaseField(AssetTypeValueField baseField)
        {
            return new JObject(
                    new JProperty(FileConstants.ScriptJObject, CreateObject(baseField))
                );
        }

        public static JProperty CreateField(AssetTypeValueField field)
        {
            return new JProperty(field.GetName(), GetValue(field));
        }

        public static JObject CreateObject(AssetTypeValueField field)
        {
            return new JObject(
                    from c in field.GetChildrenList()
                    select CreateField(c)
                );
        }

        public static JArray CreateArray(AssetTypeValueField field)
        {
            return new JArray(
                    from c in field.GetChildrenList()
                    select GetValue(c)
                );
        }

        public static JToken GetValue(AssetTypeValueField field)
        {
            int children = field.GetChildrenCount();
            string type = field.GetFieldType();

            if (children == 1 && field.GetChildrenList()[0].GetName() == "Array")
                return CreateArray(field.GetChildrenList()[0]);

            switch (type)
            {
                case "string":
                    return new JValue(field.GetValue().AsString());
                case "UInt8":
                    return new JValue(field.GetValue().AsUInt());
                case "int":
                case "Int32":
                    return new JValue(field.GetValue().AsInt());
                case "SInt64":
                    return new JValue(field.GetValue().AsInt64());
                default:
                    return CreateObject(field);
            }
        }

        /*public static string ConvertFromBaseField(AssetTypeValueField baseField)
        {
            return CreateObject(baseField);
        }

        public static string CreateField(AssetTypeValueField field)
        {
            return string.Format("\"{0}\":{1}", field.GetName(), GetValue(field));
        }

        public static string CreateObject(AssetTypeValueField field)
        {
            List<string> fields = new List<string>();
            foreach (var child in field.GetChildrenList())
            {
                fields.Add(CreateField(child));
            }
            return string.Format("{{{0}}}", string.Join(",", fields));
        }

        public static string CreateArray(AssetTypeValueField field)
        {
            List<string> fields = new List<string>();
            foreach (var child in field.GetChildrenList())
            {
                fields.Add(GetValue(child));
            }
            return string.Format("[{0}]", string.Join(",", fields));
        }

        public static string GetValue(AssetTypeValueField field)
        {
            int children = field.GetChildrenCount();
            string type = field.GetFieldType();

            if (children == 1 && field.GetChildrenList()[0].GetName() == "Array") return CreateArray(field.GetChildrenList()[0]);
            
            switch (type)
            {
                case "string":
                    return string.Format("\"{0}\"", field.GetValue().AsString());
                case "UInt8":
                    return field.GetValue().AsUInt().ToString();
                case "int":
                    return field.GetValue().AsInt().ToString();
                case "Int32":
                    return field.GetValue().AsInt().ToString();
                case "SInt64":
                    return field.GetValue().AsInt64().ToString();
                default:
                    return CreateObject(field);
            }
        }*/
    }
}
