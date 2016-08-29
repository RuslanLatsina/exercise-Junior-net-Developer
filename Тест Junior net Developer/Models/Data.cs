using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Тест_Junior_net_Developer.Models
{
    public class Data
    {
        [JsonProperty("guid")]
        public Guid Guid { get; set; }
        [JsonProperty("picture")]
        public string Picture { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("about")]
        public string About { get; set; }
        [JsonProperty("registered")]
        public DateTime Registered { get; set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
        //функція перевірки наявності тегу
        public bool HasTag(string tag)
        {
             return Tags.Any(x => x == tag);

        }
    }
}