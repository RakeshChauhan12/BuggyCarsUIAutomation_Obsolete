using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsUIAutomation.DataModel
{
    /// <summary>
    /// Existing users details for buggy cars
    /// </summary>
    public class Users
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

    }
}
