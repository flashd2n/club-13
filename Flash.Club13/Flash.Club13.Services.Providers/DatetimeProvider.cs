using Flash.Club13.Interfaces.Providers;
using System;

namespace Flash.Club13.Services.Providers
{
    public class DatetimeProvider : IDatetimeProvider
    {
        public DateTime GetToday()
        {
            return DateTime.Now;
        }

        public DayOfWeek GetCurrentDayOfWeek()
        {
            return DateTime.Now.DayOfWeek;
        }
    }
}
