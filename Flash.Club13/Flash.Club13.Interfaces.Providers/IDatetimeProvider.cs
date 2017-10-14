using System;

namespace Flash.Club13.Interfaces.Providers
{
    public interface IDatetimeProvider
    {
        DateTime GetToday();

        DayOfWeek GetCurrentDayOfWeek();
    }
}
