using Flash.Club13.Models;
using System;

namespace Flash.Club13.Interfaces.Services
{
    public interface IWorkoutService
    {
        TimeSpan? GetBestTime(DailyWorkout dailyWorkout);

        TimeSpan? GetBestTime(WorkoutInformation workout);

        int GetTotalWorkouts();
    }
}
