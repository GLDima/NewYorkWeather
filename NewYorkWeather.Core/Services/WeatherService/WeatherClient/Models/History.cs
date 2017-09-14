using Newtonsoft.Json;

namespace NewYorkWeather.Services.WeatherService.WeatherClient.Models
{
    public class History
    {
        [JsonProperty("date")]
        public Date Date { get; set; }

        [JsonProperty("utcdate")]
        public Date UTCDate { get; set; }

        [JsonProperty("observations")]
        public Observation[] Observations { get; set; }

        [JsonProperty("dailysummary")]
        public DailySummary[] Dailysummary { get; set; }
    }
}