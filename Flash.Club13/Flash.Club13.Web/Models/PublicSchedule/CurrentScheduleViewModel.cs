using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flash.Club13.Web.Models.PublicSchedule
{
    public class CurrentScheduleViewModel : IMapFrom<WeekSchedule>
    {
        public CurrentScheduleViewModel()
        {
            this.DailyWorkouts = new List<DailyWorkout>();
        }

        public DateTime WeekStart { get; set; }

        public DateTime WeekEnd { get; set; }

        public ICollection<DailyWorkout> DailyWorkouts { get; set; }

    }
}