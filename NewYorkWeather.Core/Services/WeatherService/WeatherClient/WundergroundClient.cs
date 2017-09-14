using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NewYorkWeather.Services.WeatherService.WeatherClient.Models;

namespace NewYorkWeather.Services.WeatherService.WeatherClient
{
	/// <summary>
	/// Client for Wunderground's weather API interaction.
	/// </summary>
	public sealed class WundergroundClient : IDisposable
    {
        private const string BaseUrl = "http://api.wunderground.com/api";

        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        private static string BuildUrl(string baseUrl, string apiKey, DataQueryOptions options)
        {
            if (options.Feature != DataFeature.History)
                throw new NotImplementedException($"Feature '{options.Feature}' is not supported");
            if (options.Query != DataQuery.USStateCity)
                throw new NotImplementedException($"DataQuery type '{options.Query}' is not supported");
            if (options.Date == null)
                throw new ArgumentException("Date must be supplied when querying for History");

            var sb = new StringBuilder();

            var day = options.Date.Value.Day.ToString();
            var month = options.Date.Value.Month.ToString();
            var year = options.Date.Value.Year.ToString();

            sb.AppendFormat("{0}/{1}/{2}", baseUrl, apiKey,
                string.Format("{0}_{1}{2}{3}",
                    options.Feature.ToString().ToLower(),
                    year,
                    month.Length == 1 ? $"0{month}" : month,
                    day.Length == 1 ? $"0{day}" : day));
            sb.Append("/q/");
            if (string.IsNullOrWhiteSpace(options.City))
                throw new ArgumentException($"{nameof(options.City)} have to be supplied");
            if (string.IsNullOrWhiteSpace(options.State))
                throw new ArgumentException($"{nameof(options.State)} have to be supplied");
            if (options.State.Length != 2)
                throw new ArgumentException("State abbreviation have to consist of 2 letters");
            sb.AppendFormat("{0}/{1}", options.State, options.City.Replace(" ", "_"));
            sb.Append(".json");

            return sb.ToString();
        }
        private static async Task<T> ExecuteAsync<T>(HttpClient client, Uri uri)
        {
            var response = await client.GetAsync(uri).ConfigureAwait(false);
			if (!response.IsSuccessStatusCode)
				throw new HttpRequestException(response.ReasonPhrase);
            
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if(content?.Length <= 0)
                throw new HttpRequestException("No data returned");
            if (content.Contains("keynotfound"))
                throw new ArgumentException("Invalid API key");
            
            return JsonConvert.DeserializeObject<T>(content);
        }

        public WundergroundClient(string apiKey, HttpMessageHandler clientHandler = null)
        {
            _apiKey = apiKey;
            _httpClient = clientHandler != null ? new HttpClient(clientHandler) : new HttpClient();
        }

		/// <summary>
		/// Gets the weather history with supplied options.
		/// </summary>
		/// <param name="options">Data query options.</param>
		public Task<HistoryResponse> GetHistoryAsync(DataQueryOptions options = null)
        {
            var url = BuildUrl(BaseUrl, _apiKey, options);
            return ExecuteAsync<HistoryResponse>(_httpClient, new Uri(url));

        }
        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}