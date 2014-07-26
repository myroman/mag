using System;

using Newtonsoft.Json;

namespace Mag.Business.Domain
{
    public class Agent
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("patronym")]
        public string Patronym { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("regDate")]
        public DateTime RegistrationDate { get; set; }

        [JsonProperty("isAdmin")]
        public bool? IsAdmin { get; set; }

        [JsonProperty("fullName")]
        public string FullName
        {
            get { return string.Format("{0} {1}", Name, Surname); }
        }
    }
}