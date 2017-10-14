using System.Collections.Generic;

namespace Flash.Club13.Web.Models.CompleteWorkout
{
    public class AllPendingViewModel
    {
        public AllPendingViewModel()
        {
            this.AllWorkouts = new List<AllPendingSingleWorkoutViewModel>();
        }

        public ICollection<AllPendingSingleWorkoutViewModel> AllWorkouts { get; set; }
    }
}