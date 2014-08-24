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

        public static AnalyticsSelectionFilter Quart2
        {
            get
            {
                return new AnalyticsSelectionFilter
                {
                    From = new DateTime(DateHelper.CurrentYear, 4, 1),
                    To = new DateTime(DateHelper.CurrentYear, 7, 1)
                };
            }
        }
    }
}