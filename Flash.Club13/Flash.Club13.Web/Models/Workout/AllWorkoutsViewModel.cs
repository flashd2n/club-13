using Flash.Club13.Web.Models.Home;
using System.Collections.Generic;

namespace Flash.Club13.Web.Models.Workout
{
    public class AllWorkoutsViewModel
    {
        public AllWorkoutsViewModel()
        {
            this.AllWorkouts = new List<WoDViewModel>();
        }

        public ICollection<WoDViewModel> AllWorkouts { get; set; }
    }
}