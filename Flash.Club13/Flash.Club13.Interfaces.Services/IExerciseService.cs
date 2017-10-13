using Flash.Club13.Models;
using System;
using System.Collections.Generic;

namespace Flash.Club13.Interfaces.Services
{
    public interface IExerciseService
    {
        ICollection<Exercise> GetAll();

        ICollection<string> GetAllExerciseNames();

        Exercise GetById(Guid id);

        void Update(Exercise exercise);

        void AddExercise(Exercise exercise);
    }
}
