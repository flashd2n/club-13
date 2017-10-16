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
            this.workoutInformationRepo = workoutInformationRepo ?? throw new ArgumentException("WorkoutInformation repo cannot be null");
            this.unitOfWork = unitOfWork ?? throw new ArgumentException("Unit of work cannot be null");
        }

        public ICollection<WorkoutInformation> GetAll()
        {
            return this.workoutInformationRepo.All.ToList();
        }

        public ICollection<string> GetAllNames()
        {
            return this.workoutInformationRepo.All.Select(x => x.Name).ToList();
        }

        public WorkoutInformation GetByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentException("Name cannot be null");
            }

            return this.workoutInformationRepo.All.FirstOrDefault(x => x.Name == name);
        }

        public void Update(WorkoutInformation workoutInformation)
        {
            if (workoutInformation == null)
            {
                throw new ArgumentException("WorkoutInformation cannot be null");
            }

            this.workoutInformationRepo.Update(workoutInformation);
            this.unitOfWork.Commit();
        }

        public void AddWorkoutInformation(WorkoutInformation workoutInformation)
        {
            if (workoutInformation == null)
            {
                throw new ArgumentException("WorkoutInformation cannot be null");
            }

            this.workoutInformationRepo.Add(workoutInformation);
            this.unitOfWork.Commit();
        }

        public void InsertMultipleExercisesToWorkoutInformation(WorkoutInformation workoutInformation, ICollection<Exercise> exercises)
        {
            if (workoutInformation == null)
            {
                throw new ArgumentException("WorkoutInformation cannot be null");
            }

            if (exercises == null)
            {
                throw new ArgumentException("Exercises cannot be null");
            }

            foreach (var exercise in exercises)
            {
                workoutInformation.Exercises.Add(exercise);
            }

            this.Update(workoutInformation);
        }

    }
}
