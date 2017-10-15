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
    public class DailyWorkoutService : IDailyWorkoutService
    {
        private readonly IEfRepostory<DailyWorkout> dailyWorkoutRepo;
        private readonly IUnitOfWork unitOfWork;

        public DailyWorkoutService(IEfRepostory<DailyWorkout> dailyWorkoutRepo, IUnitOfWork unitOfWork)
        {
            this.dailyWorkoutRepo = dailyWorkoutRepo ?? throw new ArgumentException("DailyWorkoutRepo Cannot be Null");
            this.unitOfWork = unitOfWork ?? throw new ArgumentException("UnitOfWork Cannot be Null");
        }

        public ICollection<DailyWorkout> GetAll()
        {
            return this.dailyWorkoutRepo.All.ToList();
        }

        public DailyWorkout GetById(Guid id)
        {
            return this.dailyWorkoutRepo.All.FirstOrDefault(x => x.Id == id);
        }

        public void Update(DailyWorkout dailyWorkout)
        {
            if (dailyWorkout == null)
            {
                throw new ArgumentException("Daily workout cannot be null");
            }

            this.dailyWorkoutRepo.Update(dailyWorkout);
            this.unitOfWork.Commit();
        }

        public void AddDailyWorkout(DailyWorkout dailyWorkout)
        {
            if (dailyWorkout == null)
            {
                throw new ArgumentException("Daily workout cannot be null");
            }

            this.dailyWorkoutRepo.Add(dailyWorkout);
            this.unitOfWork.Commit();
        }

        public void AddMemberToDailyWorkout(Member member, DailyWorkout workout)
        {
            if (member == null)
            {
                throw new ArgumentException("Member cannot be null");
            }

            if (workout == null)
            {
                throw new ArgumentException("Workout cannot be null");
            }

            workout.SignedMembers.Add(member);
            this.Update(workout);
        }

        public void AddAllDailyWorkouts(params DailyWorkout[] dailyWorkouts)
        {
            foreach (var workout in dailyWorkouts)
            {
                this.dailyWorkoutRepo.Add(workout);
            }
            
            this.unitOfWork.Commit();
        }
    }
}
