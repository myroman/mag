using Newtonsoft.Json;

namespace Mag.Business.Domain
{
    public class InsuranceType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}