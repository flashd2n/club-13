using Flash.Club13.Models;
using System.Collections.Generic;

namespace Flash.Club13.Interfaces.Services
{
    public interface IExerciseService
    {
        ICollection<Exercise> GetAll();

        void Update(Exercise exercise);

        void AddExercise(Exercise exercise);
    }
}
