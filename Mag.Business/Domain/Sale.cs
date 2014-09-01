using System;

using Newtonsoft.Json;

namespace Mag.Business.Domain
{
    public class Sale
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("agent")]
        public Agent Agent { get; set; }

        [JsonProperty("reportCode")]
        public string ReportCode { get; set; }

        [JsonProperty("create")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("createFormatted")]
        public string CreateDateFormatted
        {
            get { return CreateDate.ToJsDateString(); }
        }

        [JsonProperty("insurance")]
        public InsuranceType Insurance { get; set; }

        [JsonProperty("contractsNumber")]
        public int? ContractsNumber { get; set; }

        [JsonProperty("premium")]
        public double Premium { get; set; }

        [JsonProperty("paymentsNumber")]
        public int? PaymentsNumber { get; set; }

        [JsonProperty("paidSum")]
        public double PaidSum { get; set; }

        [JsonProperty("feePc")]
        public double FeePercent { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("addFeePc")]
        public double? AddFeePercent { get; set; }
    }
}