using System;

using Newtonsoft.Json;

namespace Mag.Business.Domain.Analytics
{
    public class AnalyticsSelectionFilter
    {
        [JsonProperty("from")]
        public DateTime From { get; set; }

        [JsonProperty("to")]
        public DateTime To { get; set; }
    }
}