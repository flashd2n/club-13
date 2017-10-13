using Flash.Club13.Models.Abstracts;
using System;
using System.Collections.Generic;

namespace Flash.Club13.Models
{
    public class WeekSchedule : DataModel
    {
        private ICollection<DailyWorkout> dailyWorkouts;

        public WeekSchedule()
        {
            this.dailyWorkouts = new HashSet<DailyWorkout>();
        }

        public DateTime WeekStart { get; set; }

        public DateTime WeekEnd { get; set; }

        public virtual ICollection<DailyWorkout> DailyWorkouts
        {
            get { return this.dailyWorkouts; }
            set { this.dailyWorkouts = value; }
        }

    }
}
