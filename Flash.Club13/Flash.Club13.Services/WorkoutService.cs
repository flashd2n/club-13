using Flash.Club13.Data.Repository;
using Flash.Club13.Data.UnitOfWork;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash.Club13.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IEfRepostory<Workout> workoutsRepo;
        private readonly IUnitOfWork unitOfWork;

        public WorkoutService(IEfRepostory<Workout> workoutsRepo, IUnitOfWork unitOfWork)
        {
            this.workoutsRepo = workoutsRepo;
            this.unitOfWork = unitOfWork;
        }

        public TimeSpan? GetBestTime(DailyWorkout dailyWorkout)
        {
            return this.workoutsRepo.All
                .Where(x => x.WorkoutInformation.Name == dailyWorkout.WorkoutInformation.Name)
                .OrderByDescending(x => x.Time)
                .Select(x => x.Time)
                .FirstOrDefault();
        }

        public TimeSpan? GetBestTime(WorkoutInformation workout)
        {
            return this.workoutsRepo.All
                .Where(x => x.WorkoutInformation.Name == workout.Name)
                .OrderByDescending(x => x.Time)
                .Select(x => x.Time)
                .FirstOrDefault();
        }

        public int GetTotalWorkouts()
        {
            return this.workoutsRepo.All.Count();
        }
    }
}
