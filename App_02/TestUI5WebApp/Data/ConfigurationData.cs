using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestUI5WebApp.Util;

namespace TestUI5WebApp.Data
{
    /// <summary>
    /// Model for configuration data
    /// </summary>
    public class ConfigurationData
    {
        public string MachineName => Environment.MachineName;

        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime StartTimeStamp = new DateTime(2019, 6, 18, 13, 23, 10, 315);

        public bool AutoRestart { get; set; } = true;

        public AutoRestartInterval AutoRestartInterval { get; set; } = AutoRestartInterval.Daily;

        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan RequestTimeout { get; set; } = TimeSpan.FromSeconds(30.5);
    }
}
