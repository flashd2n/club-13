using Flash.Club13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash.Club13.Interfaces.Services
{
    public interface IWorkoutInformationService
    {
        ICollection<WorkoutInformation> GetAll();

        void Update(WorkoutInformation workoutInformation);

        void AddWorkoutInformation(WorkoutInformation workoutInformation);

        void InsertMultipleExercisesToWorkoutInformation(WorkoutInformation workoutInformation, ICollection<Exercise> exercises);
    }
}
