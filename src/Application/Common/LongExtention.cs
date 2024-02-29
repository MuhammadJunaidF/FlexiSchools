using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Common
{
    public static class LongExtention
    {
        public static DateTime TimeStampToDateTime(this long timestamp)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(timestamp);
            DateTime dateTime = dateTimeOffset.UtcDateTime;
            return dateTime;

            //var date = new DateTime(1970,1,1,0,0,0,0,DateTimeKind.Utc).AddMilliseconds(timestamp);
            //return date;
        }

        public static long DateTimeToTimeStamp(this DateTime dateTime)
        {
            var result = Math.Round(dateTime.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds, 0);
            return Convert.ToInt64(result);
        }
    }
}
