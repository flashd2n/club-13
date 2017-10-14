using Flash.Club13.Models;
using System;
using System.Collections.Generic;

namespace Flash.Club13.Interfaces.Services
{
    public interface IDailyWorkoutService
    {
        ICollection<DailyWorkout> GetAll();

        DailyWorkout GetById(Guid id);

        void Update(DailyWorkout dailyWorkout);

        void AddDailyWorkout(DailyWorkout dailyWorkout);

        void AddMemberToDailyWorkout(Member member, DailyWorkout workout);

        void AddAllDailyWorkouts(params DailyWorkout[] dailyWorkouts);
    }
}
