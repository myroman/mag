using Mag.Business.Domain;

namespace Mag.Business.Repositories.Mappers
{
    public static class SalesMapper
    {
        public static Sale ToDomain(this tbSale from)
        {
            var domain = new Sale
                {
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
    }
}