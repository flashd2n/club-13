using Flash.Club13.Models;
using System;
using System.Collections.Generic;

namespace Flash.Club13.Interfaces.Services
{
    public interface IWeekScheduleService
    {
        ICollection<WeekSchedule> GetAll();

        WeekSchedule GetById(Guid id);

        ICollection<WeekSchedule> GetAllDescending();

        WeekSchedule GetCurrentSchedule();

        void Update(WeekSchedule weekSchedule);

        void AddWeekSchedule(WeekSchedule weekSchedule);

        void AddDailiesToSchedule(WeekSchedule schedule, params DailyWorkout[] workouts);
    }
}
