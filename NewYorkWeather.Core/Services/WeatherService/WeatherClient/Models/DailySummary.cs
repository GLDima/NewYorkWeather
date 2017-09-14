using Newtonsoft.Json;

namespace NewYorkWeather.Services.WeatherService.WeatherClient.Models
{
    public class DailySummary
    {
        [JsonProperty("date")]
        public Date Date { get; set; }

        [JsonProperty("meantempm")]
        public string MeanTemperatureM { get; set; }

        [JsonProperty("meantempi")]
        public string MeanTemperatureI { get; set; }

        [JsonProperty("maxtempm")]
        public string MaxTemperatureM { get; set; }

        [JsonProperty("maxtempi")]
        public string Maxtempi { get; set; }

        [JsonProperty("mintempm")]
        public string MinTemperatureM { get; set; }

        [JsonProperty("mintempi")]
        public string MinTemperatureI { get; set; }

		//other fields... For more go to https://www.wunderground.com/weather/api/d/docs?d=data/history#dailysummary
	}
}