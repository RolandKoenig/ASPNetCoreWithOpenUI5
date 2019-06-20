using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestUI5WebApp.Util
{
    // TimeSpanConverter from https://stackoverflow.com/questions/39876232/newtonsoft-json-serialize-timespan-format

    public class JsonTimeSpanConverter : JsonConverter<TimeSpan>
    {
        /// <summary>
        /// Compatible format for OpenUI5: hh:mm:ss
        /// </summary>
        public const string FORMAT = @"hh\:mm\:ss";

        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
        {
            var timespanFormatted = $"{value.ToString(FORMAT)}";
            writer.WriteValue(timespanFormatted);
        }

        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            TimeSpan parsedTimeSpan;
            TimeSpan.TryParseExact((string)reader.Value, FORMAT, null, out parsedTimeSpan);
            return parsedTimeSpan;
        }
    }
}
