using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class User
    {
        /// <summary>
        /// Id of the user
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Name of the user
        /// </summary>
        public string UserName { get; private set; }
        /// <summary>
        /// Password of the user
        /// </summary>
        public int Password { get; private set; }

        /// <summary>
        /// Initialize new user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        [JsonConstructor]
        public User(string userName, int password)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentNullException("Name can`t be empty");
            
            UserName = userName;
            Password = password;
        }
    }
}
