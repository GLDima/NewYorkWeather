using System;

namespace NewYorkWeather.Services.WeatherService
{
    public class WeatherClientException : Exception
    {
        public WeatherClientException(string message)
            : base(message)
        {
        }
    }
}
