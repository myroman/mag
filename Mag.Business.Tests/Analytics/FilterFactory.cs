using System;

using Mag.Business.Domain.Analytics;

namespace Mag.Business.Tests.Analytics
{
    public static class FilterFactory
    {
        public static AnalyticsSelectionFilter AllTime
        {
            get
            {
                return new AnalyticsSelectionFilter
                {
                    From = DateTime.MinValue,
                    To = DateTime.MaxValue
                };
            }
        }
    }
}