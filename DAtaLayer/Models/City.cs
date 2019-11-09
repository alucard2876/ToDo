using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    /// <summary>
    /// Class for initialize citys for the weather API
    /// </summary>
    public class City
    {
 
        /// <summary>
        /// Id of the City
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Name of the City
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Country where City placed
        /// </summary>
        public string Country { get; private set; }

        /// <summary>
        /// Initialize new city
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="country"></param>
        [JsonConstructor]
        public City(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
    }
}
