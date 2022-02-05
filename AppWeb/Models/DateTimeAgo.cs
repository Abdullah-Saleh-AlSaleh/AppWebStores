using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.Models
{
    public class DateTimeAgo
    {
        public static string TimeAgo(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;
                return String.Format("منذ {0} {1} ",
                years, years == 1 ? "عام" : "سنوات");
            }
            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return String.Format("منذ {0} {1} ",
                months, months == 1 ? "شهر" : "الشهور");
            }
            if (span.Days > 0)
                return String.Format("منذ {0} {1} ",
                span.Days, span.Days == 1 ? "يوم" : "أيام");
            if (span.Hours > 0)
                return String.Format("منذ {0} {1} ",
                span.Hours, span.Hours == 1 ? "ساعة" : "ساعات");
            if (span.Minutes > 0)
                return String.Format("منذ {0} {1} ",
                span.Minutes, span.Minutes == 1 ? "دقيقة" : "الدقائق");
            if (span.Seconds > 5)
                return String.Format(" {0} منذ ثوانى", span.Seconds);
            if (span.Seconds <= 5)
                return "الآن";

            return string.Empty;
        }

    }
}