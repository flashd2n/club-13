using Flash.Club13.Models;
using System.Collections.Generic;

namespace Flash.Club13.Interfaces.Services
{
    public interface IWorkoutInformationService
    {
        ICollection<WorkoutInformation> GetAll();

        ICollection<string> GetAllNames();

        WorkoutInformation GetByName(string name);

        void Update(WorkoutInformation workoutInformation);

        void AddWorkoutInformation(WorkoutInformation workoutInformation);

        void InsertMultipleExercisesToWorkoutInformation(WorkoutInformation workoutInformation, ICollection<Exercise> exercises);
    }
}
