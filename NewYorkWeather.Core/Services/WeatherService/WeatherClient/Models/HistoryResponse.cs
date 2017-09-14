using Newtonsoft.Json;

namespace NewYorkWeather.Services.WeatherService.WeatherClient.Models
{
    public class HistoryResponse
    {
        [JsonProperty("response")]
        public Response Response { get; set; }

        [JsonProperty("history")]
        public History History { get; set; }
    }
}