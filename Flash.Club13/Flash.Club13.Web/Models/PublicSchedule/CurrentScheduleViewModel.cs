using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Automapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime WeekStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime WeekEnd { get; set; }

        public ICollection<DailyWorkout> DailyWorkouts { get; set; }

    }
}