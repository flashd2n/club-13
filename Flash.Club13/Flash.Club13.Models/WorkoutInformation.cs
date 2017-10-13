using Flash.Club13.Models.Abstracts;
using System;
using System.Collections.Generic;

namespace Flash.Club13.Models
{
    public class WorkoutInformation : DataModel
    {
        private ICollection<Exercise> exercises;

        public WorkoutInformation()
        {
            this.exercises = new HashSet<Exercise>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Exercise> Exercises
        {
            get { return this.exercises; }
            set { this.exercises = value; }
        }

        public string VideoLink { get; set; }

        public TimeSpan? BestTime { get; set; }
    }
}
