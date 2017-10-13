using Flash.Club13.Data.Repository;
using Flash.Club13.Data.UnitOfWork;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
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
            this.exercisesRepo = exercisesRepo;
            this.unitOfWork = unitOfWork;
        }

        public ICollection<Exercise> GetAll()
        {
            return this.exercisesRepo.All.ToList();
        }

        public void Update(Exercise exercise)
        {
            this.exercisesRepo.Update(exercise);
            this.unitOfWork.Commit();
        }

        public void AddExercise(Exercise exercise)
        {
            this.exercisesRepo.Add(exercise);
            this.unitOfWork.Commit();
        }

    }
}
