using System;

namespace Mag.Business
{
    public static class DateHelper
    {
        public static string ToJsDateString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}