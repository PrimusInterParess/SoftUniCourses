using System;
using System.Collections.Generic;
using System.Text;

namespace _5.DateModifier
{
    public static class DateModifier
    {

        public static int ReturnsTotalDays(string start, string end)
        {
            DateTime startDateTime = DateTime.Parse(start);

            DateTime enDateTime = DateTime.Parse(end);

            int totalDays = (int)(startDateTime - enDateTime).TotalDays;

            return Math.Abs(totalDays);
        }
    }
}
