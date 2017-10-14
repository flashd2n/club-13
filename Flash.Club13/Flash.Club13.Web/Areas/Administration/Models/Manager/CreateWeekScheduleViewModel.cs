using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Automapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flash.Club13.Web.Areas.Administration.Models
{
    public class CreateWeekScheduleViewModel : IMapFrom<WeekSchedule>
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WeekStart { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WeekEnd { get; set; }
    }
}