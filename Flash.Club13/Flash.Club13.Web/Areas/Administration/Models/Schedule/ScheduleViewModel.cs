using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Automapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Flash.Club13.Web.Areas.Administration.Models.Schedule
{
    public class ScheduleViewModel : IMapFrom<WeekSchedule>
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime WeekStart { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime WeekEnd { get; set; }
    }
}