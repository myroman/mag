using System;

using Mag.Business.Domain;

namespace Mag.Business.Tests.Analytics
{
    public static class SaleFactory
    {
        public static Sale NewSale
        {
            get { return new Sale().CreateDate(DateTime.Now).Insurance(InsuranceFactory.Rand); }
        }

        public static Sale PaidSum(this Sale sale, int val)
        {
            sale.PaidSum = val;
            return sale;
        }

        public static Sale Insurance(this Sale sale, InsuranceType obj)
        {
            sale.Insurance = obj;
            return sale;
        }

        public static Sale ContractsNumber(this Sale sale, int val)
        {
            sale.ContractsNumber = val;
            return sale;
        }

        public static Sale CreateDate(this Sale sale, DateTime val)
        {
            sale.CreateDate = val;
            return sale;
        }

        public static Sale Agent(this Sale sale, Agent val)
        {
            sale.Agent = val;
            return sale;
        }
    }
}