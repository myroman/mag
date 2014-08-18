using Newtonsoft.Json;

namespace Mag.Business.Domain.Analytics
{
    public class AnalyticsRecord
    {
        [JsonProperty("insuranceType")]
        public string InsuranceType { get; set; }

        [JsonProperty("totalSum")]
        public double TotalSum { get; set; }

        [JsonProperty("totalContractsNumber")]
        public int TotalContractsNumber { get; set; }
    }
}