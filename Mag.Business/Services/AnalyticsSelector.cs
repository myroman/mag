using System.Collections.Generic;
using System.Linq;

using Mag.Business.Abstract;
using Mag.Business.Domain;
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
            var salesToFilter = FilterSales(filter);
            return GroupSales(salesToFilter);
        }

        private static IEnumerable<AnalyticsRecord> GroupSales(IEnumerable<Sale> salesToFilter)
        {
            var salesByInsurance = salesToFilter.GroupBy(x => x.Insurance, x => x);

            var groupedSales = salesByInsurance
                .Select(salesWithSimilarInsurance => new AnalyticsRecord
                {
                    CategoryName = salesWithSimilarInsurance.Key.Name,
                    TotalContractsNumber = salesWithSimilarInsurance.Sum(x => x.ContractsNumber.GetValueOrDefault()),
                    TotalSum = salesWithSimilarInsurance.Sum(x => x.PaidSum)
                }).ToList();

            var total = new AnalyticsRecord
            {
                CategoryName = "Итого:",
                TotalSum = groupedSales.Sum(x => x.TotalSum),
                TotalContractsNumber = groupedSales.Sum(x => x.TotalContractsNumber),
                UseCapslockLetters = true
            };
            groupedSales.Add(total);
            return groupedSales;
        }

        private IEnumerable<Sale> FilterSales(AnalyticsSelectionFilter filter)
        {
            var salesToFilter = salesRepository.ReadSales()
                .OrderBy(x => x.CreateDate)
                .Where(x => x.CreateDate >= filter.From && x.CreateDate <= filter.To);
            if (filter.Agent != null)
            {
                salesToFilter = salesToFilter.Where(x => x.Agent.Equals(filter.Agent));
            }
            return salesToFilter;
        }
    }
}