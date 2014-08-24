using Newtonsoft.Json;

namespace Mag.Business.Domain.Analytics
{
    public class AnalyticsRecord
    {
        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("totalSum")]
        public double TotalSum { get; set; }

        [JsonProperty("totalContractsNumber")]
        public int TotalContractsNumber { get; set; }

        [JsonProperty("useCaps")]
        public bool UseCapslockLetters { get; set; }
    }
}