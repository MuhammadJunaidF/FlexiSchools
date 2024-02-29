using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Common.Extensions
{
    public static class DateTimeExtension
    {
        public static string DbFormat(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static DateTime TimeRoundOf(this DateTime stamp, int roundBy = 5)
        {
            stamp = stamp.AddMinutes(-(stamp.Minute % roundBy));
            stamp = stamp.AddMilliseconds(-stamp.Millisecond - 1000 * stamp.Second);
            return stamp;
        }
        public static DateTime TimestampToDateTime(this long timeStamp)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(timeStamp);
            DateTime dateTime = dateTimeOffset.UtcDateTime;
            return dateTime;
        }
    }
}
