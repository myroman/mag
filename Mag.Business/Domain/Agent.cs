﻿using System;

using Newtonsoft.Json;

namespace Mag.Business.Domain
{
    public class Agent
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

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

        [JsonIgnore]
        public string AccessCode { get; set; }

        public override string ToString()
        {
            return string.Format("Agent(Id={0},Login={4},Name={1},Pwd={2},Hash={3})", Id, FullName, Password, PasswordHash, Login);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Agent;
            if (other == null)
            {
                return false;
            }
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}