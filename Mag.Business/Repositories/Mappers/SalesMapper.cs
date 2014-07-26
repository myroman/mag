using Mag.Business.Domain;

namespace Mag.Business.Repositories.Mappers
{
    public static class SalesMapper
    {
        public static Sale ToDomain(this tbSale from)
        {
            var domain = new Sale
                {
                    Id = from.id,
                    ReportCode = from.reportCode,
                    CreateDate = from.createDate,
                    ContractsNumber = from.contractsNumber,
                    Premium = from.premium,
                    PaymentsNumber = from.paymentsNumber,
                    PaidSum = from.paidSum,
                    FeePercent = from.feePercent,
                    Comment = from.comment,
                    AddFeePercent = from.addFeePercent
                };
            return domain;
        }

        public static tbSale ToItem(this Sale from)
        {
            var item = new tbSale
                {
                    agentId = from.Agent.Id,
                    insuranceTypeId = from.Insurance.Id,
                    reportCode = from.ReportCode,
                    createDate = from.CreateDate,
                    contractsNumber = from.ContractsNumber,
                    premium = from.Premium,
                    paymentsNumber = from.PaymentsNumber,
                    paidSum = from.PaidSum,
                    feePercent = from.FeePercent,
                    comment = from.Comment,
                    addFeePercent = from.AddFeePercent
                };
            return item;
        }
    }
}