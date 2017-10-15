using Flash.Club13.Web.Areas.Administration.Models;
using Flash.Club13.Web.Areas.Administration.Models.Schedule;
using Flash.Club13.Web.Models.CompleteWorkout;
using Flash.Club13.Web.Models.Home;
using Flash.Club13.Web.Models.Workout;
using System;
using System.Collections.Generic;

namespace Flash.Club13.Web.Infrastructure.Factories
{
    public interface IModelViewFactory
    {
        CreateWorkoutViewModel CreateCreateWorkoutViewModel(IList<ExerciseMutipleSelectionViewModel> exercises);
        AllSchedulesViewModel CreateAllSchedulesViewModel(ICollection<ScheduleViewModel> schedules);
        AllPendingViewModel CreateAllPendingViewModel();
        CompleteViewModel CreateCompleteViewModel(Guid id);
        TotalMembersViewModel CreateTotalMembersViewModel(int count);
        TotalWorkoutsViewModel CreateTotalWorkoutsViewModel(int count);
        SignUpWoDViewModel CreateSignUpWoDViewModel();
        AllWorkoutsViewModel CreateAllWorkoutsViewModel();
    }
}
