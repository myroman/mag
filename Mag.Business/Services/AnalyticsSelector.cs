using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using Mag.Business.Abstract;
using Mag.Business.Domain.Analytics;

namespace Mag.Business.Services
{
    public class AnalyticsSelector : IAnalyticsSelector
    {
        private readonly ISalesRepository salesRepository;

        public AnalyticsSelector(ISalesRepository salesRepository)
        {
            this.salesRepository = salesRepository;
        }

        public IEnumerable<AnalyticsRecord> CalculateReport(AnalyticsSelectionFilter filter)
        {
            Thread.Sleep(2000);
            var allSales = salesRepository.ReadSales().ToArray();

            var salesByInsurance = allSales.GroupBy(x => x.Insurance, x => x);
            return salesByInsurance.Select(salesWithSimilarInsurance => new AnalyticsRecord
            {
                InsuranceType = salesWithSimilarInsurance.Key.Name, 
                TotalContractsNumber = salesWithSimilarInsurance.Sum(x => x.ContractsNumber.GetValueOrDefault()), 
                TotalSum = salesWithSimilarInsurance.Sum(x => x.PaidSum)
            }).ToList();
        }
    }
}