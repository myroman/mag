using System;

using Newtonsoft.Json;

namespace Mag.Business.Domain
{
    public class Agent
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("regDate")]
        public DateTime RegistrationDate { get; set; }

        [JsonProperty("isAdmin")]
        public bool? IsAdmin { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public string ConfirmPassword { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; internal set; }
    }
}