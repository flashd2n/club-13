using Flash.Club13.Data.Repository;
using Flash.Club13.Data.UnitOfWork;
using Flash.Club13.Interfaces.Providers;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash.Club13.Services
{
    public class WeekScheduleService : IWeekScheduleService
    {
        private readonly IEfRepostory<WeekSchedule> weekScheduleRepo;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDatetimeProvider datetimeProvider;

        public WeekScheduleService(IEfRepostory<WeekSchedule> weekScheduleRepo, IUnitOfWork unitOfWork, IDatetimeProvider datetimeProvider)
        {
            this.weekScheduleRepo = weekScheduleRepo;
            this.unitOfWork = unitOfWork;
            this.datetimeProvider = datetimeProvider;
        }

        public ICollection<WeekSchedule> GetAll()
        {
            return this.weekScheduleRepo.All.ToList();
        }

        public WeekSchedule GetById(Guid id)
        {
            return this.weekScheduleRepo.All.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<WeekSchedule> GetAllDescending()
        {
            return this.weekScheduleRepo.All.OrderByDescending(x => x.WeekStart).ToList();
        }

        public WeekSchedule GetCurrentSchedule()
        {
            var today = this.datetimeProvider.GetToday();
            
            var schedule = this.weekScheduleRepo.All
                .FirstOrDefault(x => today.Day <= x.WeekEnd.Day && today >= x.WeekStart && today.Month <= x.WeekEnd.Month && today.Month >= x.WeekStart.Month);
            return schedule;
        }

        public void Update(WeekSchedule weekSchedule)
        {
            this.weekScheduleRepo.Update(weekSchedule);
            this.unitOfWork.Commit();
        }

        public void AddWeekSchedule(WeekSchedule weekSchedule)
        {
            this.weekScheduleRepo.Add(weekSchedule);
            this.unitOfWork.Commit();
        }

        public void AddDailiesToSchedule(WeekSchedule schedule, params DailyWorkout[] workouts)
        {
            foreach (var wod in workouts)
            {
                schedule.DailyWorkouts.Add(wod);
            }
            this.Update(schedule);
        }
    }
}
