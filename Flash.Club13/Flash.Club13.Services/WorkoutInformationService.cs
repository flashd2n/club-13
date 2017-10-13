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
    public class WorkoutInformationService : IWorkoutInformationService
    {
        private readonly IEfRepostory<WorkoutInformation> workoutInformationRepo;
        private readonly IUnitOfWork unitOfWork;

        public WorkoutInformationService(IEfRepostory<WorkoutInformation> workoutInformationRepo, IUnitOfWork unitOfWork)
        {
            this.workoutInformationRepo = workoutInformationRepo;
            this.unitOfWork = unitOfWork;
        }

        public ICollection<WorkoutInformation> GetAll()
        {
            return this.workoutInformationRepo.All.ToList();
        }

        public void Update(WorkoutInformation workoutInformation)
        {
            this.workoutInformationRepo.Update(workoutInformation);
            this.unitOfWork.Commit();
        }

        public void AddWorkoutInformation(WorkoutInformation workoutInformation)
        {
            this.workoutInformationRepo.Add(workoutInformation);
            this.unitOfWork.Commit();
        }

        public void InsertMultipleExercisesToWorkoutInformation(WorkoutInformation workoutInformation, ICollection<Exercise> exercises)
        {
            foreach (var exercise in exercises)
            {
                workoutInformation.Exercises.Add(exercise);
            }

            this.Update(workoutInformation);
        }

    }
}
