using System;

using Newtonsoft.Json;

namespace Mag.Business.Domain
{
    public class InsuranceType : IEquatable<InsuranceType>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(InsuranceType other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return obj is InsuranceType && Equals((InsuranceType)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}