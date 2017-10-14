using Flash.Club13.Models;
using System.Collections.Generic;

namespace Flash.Club13.Interfaces.Services
{
    public interface IDailyWorkoutService
    {
        ICollection<DailyWorkout> GetAll();

        void Update(DailyWorkout dailyWorkout);

        void AddDailyWorkout(DailyWorkout dailyWorkout);

        void AddAllDailyWorkouts(params DailyWorkout[] dailyWorkouts);
    }
}
