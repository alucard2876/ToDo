using DataLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BuisnessLayer.Controllers
{
    public class WeatherController
    {
        /// <summary>
        /// Settings for setup weather
        /// </summary>
        public WeatherSettings Settings { get; private set; }
        /// <summary>
        /// Information about weather
        /// </summary>
        public WeatherInfo Info { get; private set; }
        /// <summary>
        /// URL for connect to server
        /// </summary>
        private readonly string URL;

        /// <summary>
        /// Constructor with initialize settigs
        /// </summary>
        /// <param name="settings"></param>
        public WeatherController(WeatherSettings settings)
        {
            if (settings == null) throw new ArgumentNullException("Settings is null");
            Settings = settings;
            URL = $"https://api.openweathermap.org/data/2.5/weather?q={settings.City},{settings.Country.ToLower()}&units={settings.MeasuringSystem.ToLower()}&appid=d8ca4d14db3db7c3110e3bca679cd620";
            ReadWeather();
        }
        /// <summary>
        /// Setup and get information
        /// </summary>
        /// <returns></returns>
        private WeatherInfo ReadWeather()
        {
            var requset = (HttpWebRequest)WebRequest.Create(URL);
            var responce = (HttpWebResponse)requset.GetResponse();
            using (var sr = new StreamReader(responce.GetResponseStream()))
            {
                var str = sr.ReadToEnd();
                return Info = JsonConvert.DeserializeObject<WeatherInfo>(str);
            }
        }

        /// <summary>
        /// Get information about current weather
        /// </summary>
        /// <returns></returns>
        public string GetCurrentWeather()
        {
            return $" Weather on today is: {Info.Main.Temp} deg; {Info.Weather.First().Main}, {Info.Weather.First().Description}; Wind: {Info.Wind.Speed}";
            
        }
    }
}
