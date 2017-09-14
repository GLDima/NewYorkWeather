using Newtonsoft.Json;

namespace NewYorkWeather.Services.WeatherService.WeatherClient.Models
{
    public class Observation
    {
        [JsonProperty("date")]
        public Date Date { get; set; }

        [JsonProperty("utcdate")]
        public Date UTCDate { get; set; }

        [JsonProperty("tempm")]
        public string TemperatureM { get; set; }

        [JsonProperty("tempi")]
        public string TemperatureI { get; set; }

		//other fields ... For more go to https://www.wunderground.com/weather/api/d/docs?d=data/history#observations
	}
}