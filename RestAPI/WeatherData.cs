using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI
{
    public class WeatherData
    {
        [JsonProperty("name")]
        public string City { get; set; }

        [JsonProperty("main")]
        public TemperatureInfo Temperature { get; set; }
    }

    public class TemperatureInfo
    {
        [JsonProperty("temp")]
        public float Temperature { get; set; }
    }
}
