using Flash.Club13.Models;
using System;

namespace Flash.Club13.Interfaces.Services
{
    public interface IWorkoutService
    {
        TimeSpan? GetBestTimeDaily(DailyWorkout dailyWorkout);

        TimeSpan? GetBestTime(WorkoutInformation workout);

        int GetTotalWorkouts();
    }
}
