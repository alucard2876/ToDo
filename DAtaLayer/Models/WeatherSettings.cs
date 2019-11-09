using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    /// <summary>
    /// Class for setup weather settings
    /// </summary>
    public class WeatherSettings
    {
     

        /// <summary>
        /// Country where weather will be search
        /// </summary>
        public string Country { get; private set; }
        /// <summary>
        /// City where weather will be search
        /// </summary>
        public string City { get; private set; }
        /// <summary>
        /// Measuring degres
        /// </summary>
        public string MeasuringSystem { get; private set; }

        /// <summary>
        /// Initialize settings
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="measuringSystem"></param>
        public WeatherSettings(string country, string city, string measuringSystem)
        {
            if (string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(measuringSystem))
                throw new ArgumentNullException("One or more field is empty");
            Country = country;
            City = city;
            MeasuringSystem = measuringSystem;
        }
    }
}
