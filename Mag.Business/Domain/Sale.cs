using System;

namespace Mag.Business.Domain
{
    public class Sale
    {
        public Agent Agent { get; set; }

        public string ReportCode { get; set; }

        public DateTime CreateDate { get; set; }

        public InsuranceType Insurance { get; set; }

        public int? ContractsNumber { get; set; }

        public double Premium { get; set; }

        public int? PaymentsNumber { get; set; }

        public double PaidSum { get; set; }

        public double FeePercent { get; set; }

        public double Fee
        {
            get { return PaidSum * FeePercent; }
        }

        public string Comment { get; set; }

        public double? AddFeePercent { get; set; }

        public double AddFee
        {
            get { return PaidSum * AddFeePercent.GetValueOrDefault(0); }
        }
    }
}