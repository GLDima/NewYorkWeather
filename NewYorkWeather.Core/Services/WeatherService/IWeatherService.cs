using System;
using System.Threading.Tasks;

namespace NewYorkWeather.Services.WeatherService
{
	/// <summary>
	/// This service generate weather reports.
	/// </summary>
	public interface IWeatherService
    {
		/// <summary>
		/// Generates report about weather in New York for the suplied date.
		/// </summary>
		/// <param name="date">Date for reporting.</param>
		Task<string> GetNYWeatherReportAsync(DateTime date);
    }
}