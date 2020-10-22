using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboJo
{
    /// <summary>
    /// Allows you to round a time to the nearest quarter of an hour (or half hour, etc)
    /// Special thanks to Baldrick of Stackoverflow for this one
    /// https://stackoverflow.com/questions/24006244/roundoff-timespan-to-15-min-interval?lq=1
    /// </summary>
    public static class TimeSpanExtensions
    {
        public static TimeSpan RoundToNearestMinutes(this TimeSpan input, int minutes)
        {
            var totalMinutes = (int)(input + new TimeSpan(0, minutes / 2, 0)).TotalMinutes;

            return new TimeSpan(0, totalMinutes - totalMinutes % minutes, 0);
        }
    }
}
