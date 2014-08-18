using System.Collections.Generic;

using Mag.Business.Abstract;
using Mag.Business.Domain.Analytics;

namespace Mag.Business.Services
{
    public class AnalyticsSelector : IAnalyticsSelector
    {
        public IEnumerable<AnalyticsRecord> CalculateReport(AnalyticsSelectionFilter filter)
        {
            var stubResults = new List<AnalyticsRecord>
            {
                new AnalyticsRecord
                {
                    InsuranceType = "ДАГО",
                    TotalContractsNumber = 1,
                    TotalSum = 1500
                }
            };
            return stubResults;
        }
    }
}