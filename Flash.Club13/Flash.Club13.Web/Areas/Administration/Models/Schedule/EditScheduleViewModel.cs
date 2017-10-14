using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Automapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flash.Club13.Web.Areas.Administration.Models.Schedule
{
    public class EditScheduleViewModel : IMapFrom<WeekSchedule>
    {
        public EditScheduleViewModel()
        {
            this.AllWorkouts = new Dictionary<string, DailyWorkoutViewModel>();
        }

        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime WeekStart { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime WeekEnd { get; set; }

        public Dictionary<string, DailyWorkoutViewModel> AllWorkouts { get; set; }

        //public DailyWorkoutViewModel Monday { get; set; }

        //public DailyWorkoutViewModel Tuesday { get; set; }

        //public DailyWorkoutViewModel Wednesday { get; set; }

        //public DailyWorkoutViewModel Thursday { get; set; }

        //public DailyWorkoutViewModel Friday { get; set; }

        //public DailyWorkoutViewModel Saturday { get; set; }

        //public DailyWorkoutViewModel Sunday { get; set; }
    }
}