using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Тест_Junior_net_Developer.Models
{
    public class Accounts
    {
        [Required]
        [JsonProperty("login")]
        public string Login { get; set; }
        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
   
}