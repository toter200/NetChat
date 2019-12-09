using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NCSharedlib
{
    public class IpAddressConverter :  JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IPAddress));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IPAddress ip = (IPAddress) value;
            JToken jt = JToken.FromObject(ip.ToString(), serializer);
            jt.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
           JObject jo = JObject.Load(reader);
           IPAddress address = jo["IPAddress"].ToObject<IPAddress>(serializer);
           return address;
        }
    }
}