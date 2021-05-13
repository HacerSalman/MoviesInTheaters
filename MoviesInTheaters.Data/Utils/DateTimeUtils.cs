using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesInTheaters.Data.Utils
{
    public static class DateTimeUtils
    {     

        public static long GetCurrentTicks()
        {
            return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
        }

        public static long GetDateTicks(DateTime dt)
        {
            return (long)dt.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

     
    }
}
