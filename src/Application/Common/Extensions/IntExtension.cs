using FlexiSchools.Application.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace FlexiSchools.Application.Common.Extensions
{
    public static class IntExtension
    {
        public static int ConvertToInt(this int? value)
        {
            return value.HasValue ? value.Value : 0;
        }

        public static long ConvertToLong(this long? value)
        {
            return value.HasValue ? value.Value : 0;
        }

        public static decimal ConvertToMbs(this decimal value, DataConsumptionType dataType)
        {
            if (dataType == DataConsumptionType.Mb) return value;

            return value * 1024;
        }

        public static decimal ConvertToGbs(this decimal value)
        {
            if (value < 1024) return value;

            return value / 1024;
        }

        public static int ConvertToDays(this int valueinWeeks)
        {
            return valueinWeeks * 7;
        }

        public static int ConvertToDays(this int valueinWeeks, int days)
        {
            return valueinWeeks * days;
        }

        public static decimal ConvertToMbs(this decimal valueInMbs)
        {
            return valueInMbs * 1024 * 1024;
        }
    }
}
