using Newtonsoft.Json;

namespace NewYorkWeather.Services.WeatherService.WeatherClient.Models
{
    public class Date
    {
        [JsonProperty("pretty")]
        public string PrettyDate { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("mon")]
        public string Month { get; set; }

        [JsonProperty("mday")]
        public string Day { get; set; }

        [JsonProperty("hour")]
        public string Hour { get; set; }

        [JsonProperty("min")]
        public string Minute { get; set; }

        [JsonProperty("tzname")]
        public string TimeZoneName { get; set; }
    }
}