using System;

namespace NewYorkWeather.Services.WeatherService.WeatherClient
{
	/// <summary>
	/// Options for request query to the Wunderground server.
	/// </summary>
	public class DataQueryOptions
    {
		/// <summary>
		/// The data feature type from Wunderground.com API
		/// </summary>
		public DataFeature Feature { get; set; } = DataFeature.History;

        /// <summary>
        /// The location for which you want weather information
        /// </summary>
        public DataQuery Query { get; set; } = DataQuery.USStateCity;

        /// <summary>
        /// City name
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// US state name
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Date for History feature
        /// </summary>
        public DateTime? Date { get; set; }

        //other options could be pasted here...
    }

    /// <summary>
    /// The location for which you want weather information
    /// </summary>
    public enum DataQuery
    {
        /// <summary>
        /// Query with US City and State.
        /// </summary>
        USStateCity = 6,

		//other types... For mor info go to https://www.wunderground.com/weather/api/d/docs?d=data/index section query
	}

    /// <summary>
    /// Data Features which can be accessed
    /// </summary>
    public enum DataFeature
    {
        History
		//other features... For more info go to https://www.wunderground.com/weather/api/d/docs?d=data/index section features
	}
}