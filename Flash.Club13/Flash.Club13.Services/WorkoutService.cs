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
            this.workoutsRepo = workoutsRepo ?? throw new ArgumentException("Workouts repo cannot be null");
            this.unitOfWork = unitOfWork ?? throw new ArgumentException("Unit fo work cannot be null");
        }

        public TimeSpan? GetBestTimeDaily(DailyWorkout dailyWorkout)
        {
            if (dailyWorkout == null)
            {
                throw new ArgumentException("Daily workout cannot be null");
            }

            return this.workoutsRepo.All
                .Where(x => x.WorkoutInformation.Name == dailyWorkout.WorkoutInformation.Name)
                .OrderBy(x => x.Time)
                .Select(x => x.Time)
                .FirstOrDefault();
        }

        public TimeSpan? GetBestTime(WorkoutInformation workout)
        {
            if (workout == null)
            {
                throw new ArgumentException("Workout cannot be null");
            }

            return this.workoutsRepo.All
                .Where(x => x.WorkoutInformation.Name == workout.Name)
                .OrderBy(x => x.Time)
                .Select(x => x.Time)
                .FirstOrDefault();
        }

        public int GetTotalWorkouts()
        {
            return this.workoutsRepo.All.Count();
        }
    }
}
