using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NewYorkWeather.Services.WeatherService.WeatherClient;

namespace NewYorkWeather.Services.WeatherService
{
    public sealed class WeatherService : IWeatherService, IDisposable
    {
        private const string ApiKey = "e4c86d98cf0ff2d4";
        private const string Sity = "New York";
        private const string State = "NY";

        private readonly WundergroundClient _client;

		public WeatherService(HttpMessageHandler clientHandler = null)
		{
			_client = new WundergroundClient(ApiKey, clientHandler);
		}

        public async Task<string> GetNYWeatherReportAsync(DateTime date)
        {
            var history = await _client.GetHistoryAsync(new DataQueryOptions {City = Sity, State = State, Date = date });
            if (history.Response.Error != null && history.Response.Error.Any())
                throw new WeatherClientException(history.Response.Error.Aggregate(new StringBuilder("Response error:" + Environment.NewLine), (s, pair) => s.AppendLine($"{pair.Key} : {pair.Value}"), s => s.ToString()));

            var daily = history.History.Dailysummary?.FirstOrDefault();
            return daily == null
                ? "Sorry, there is no data"
                : $"The temperature in New York was {daily.MeanTemperatureI}f ({daily.MeanTemperatureM}c) at {daily.Date.PrettyDate}";
        }
        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
