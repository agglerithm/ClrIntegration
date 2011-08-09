using System;

namespace cjrCommon.Extensions
{
#pragma warning disable 1591
    public static class DateExtensions
    {
        public static DateTime Truncate(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day);
        }
    }
}
