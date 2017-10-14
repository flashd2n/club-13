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
            this.dailyWorkoutRepo = dailyWorkoutRepo;
            this.unitOfWork = unitOfWork;
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
            this.dailyWorkoutRepo.Update(dailyWorkout);
            this.unitOfWork.Commit();
        }

        public void AddDailyWorkout(DailyWorkout dailyWorkout)
        {
            this.dailyWorkoutRepo.Add(dailyWorkout);
            this.unitOfWork.Commit();
        }

        public void AddMemberToDailyWorkout(Member member, DailyWorkout workout)
        {
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
