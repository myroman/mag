using System;

namespace Mag.Business
{
    public static class DateHelper
    {
        public static string ToJsDateString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static int CurrentYear
        {
            get { return DateTime.Now.Year; }
        }

        public static DateTime YearBegin
        {
            get { return new DateTime(CurrentYear, 1, 1); }
        }

        public static DateTime YearEnd
        {
            get { return new DateTime(CurrentYear, 12, 31); }
        }

        public static DateTime Quart1
        {
            get { return YearBegin; }
        }

        public static DateTime Quart2
        {
            get { return YearBegin.AddMonths(3); }
        }

        public static DateTime Quart3
        {
            get { return YearBegin.AddMonths(6); }
        }

        public static DateTime Quart4
        {
            get { return YearBegin.AddMonths(9); }
        }
    }
}