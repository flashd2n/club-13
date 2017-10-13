using Flash.Club13.Models.Abstracts;
using System.Collections.Generic;

namespace Flash.Club13.Models
{
    public class Exercise : DataModel
    {
        private ICollection<WorkoutInformation> workouts;

        public Exercise()
        {
            this.workouts = new HashSet<WorkoutInformation>();
        }

        public string Name { get; set; }

        public virtual ICollection<WorkoutInformation> Workouts
        {
            get { return this.workouts; }
            set { this.workouts = value; }
        }
    }
}
