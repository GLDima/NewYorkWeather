using System.Collections.Generic;
using Newtonsoft.Json;

namespace NewYorkWeather.Services.WeatherService.WeatherClient.Models
{
    public class Response
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("termsofService")]
        public string TermsofService { get; set; }

        [JsonProperty("features")]
        public Dictionary<string, string> Features { get; set; }

        [JsonProperty("error")]
        public Dictionary<string, string> Error { get; set; }
    }
}