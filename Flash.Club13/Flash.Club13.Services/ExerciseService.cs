using Flash.Club13.Data.Repository;
using Flash.Club13.Data.UnitOfWork;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flash.Club13.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IEfRepostory<Exercise> exercisesRepo;
        private readonly IUnitOfWork unitOfWork;

        public ExerciseService(IEfRepostory<Exercise> exercisesRepo, IUnitOfWork unitOfWork)
        {
            this.exercisesRepo = exercisesRepo ?? throw new ArgumentException("Exercise Repo cannot be null");
            this.unitOfWork = unitOfWork ?? throw new ArgumentException("UnitOfWork cannot be null");
        }

        public ICollection<Exercise> GetAll()
        {
            return this.exercisesRepo.All.ToList();
        }

        public ICollection<string> GetAllExerciseNames()
        {
            return this.exercisesRepo.All.Select(exercise => exercise.Name).ToList();
        }

        public Exercise GetById(Guid id)
        {
            return this.exercisesRepo.All.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Exercise exercise)
        {
            if (exercise == null)
            {
                throw new ArgumentException("Exercise cannot be null");
            }

            this.exercisesRepo.Update(exercise);
            this.unitOfWork.Commit();
        }

        public void AddExercise(Exercise exercise)
        {
            if (exercise == null)
            {
                throw new ArgumentException("Exercise cannot be null");
            }

            this.exercisesRepo.Add(exercise);
            this.unitOfWork.Commit();
        }

    }
}
