using System.Collections.Generic;

using Mag.Business.Domain.Analytics;

namespace Mag.Business.Abstract
{
    public interface IAnalyticsSelector
    {
        IEnumerable<AnalyticsRecord> CalculateReport(AnalyticsSelectionFilter filter);
    }
}