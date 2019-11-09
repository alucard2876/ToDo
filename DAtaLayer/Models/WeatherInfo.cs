using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class WeatherInfo
    {
     
        /// <summary>
        /// Weather information
        /// </summary>
        public List<Weather> Weather { get; private set; }
        /// <summary>
        /// Temperature information
        /// </summary>
        public TempInfo Main { get; private set; }
        /// <summary>
        /// Wind information
        /// </summary>
        public Wind Wind { get; private set; }
        [JsonConstructor]
        public WeatherInfo(List<Weather> weather, TempInfo main, Wind wind)
        {
            Weather = weather;
            Main = main;
            Wind = wind;
        }
    }
    public class Weather
    {
        public string Main { get;  set; }
        public string Description { get;  set; }
    }
    public class TempInfo
    {
        public double Temp { get; set; }
        public double Min_Temp { get; set; }
        public double Max_Temp { get; set; }

    }
    public class Wind
    {
        public double Speed { get; set; }
    }
}
