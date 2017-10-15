using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Attributes;
using Flash.Club13.Web.Infrastructure.Automapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flash.Club13.Web.Areas.Administration.Models
{
    [WeekDateSelect]
    public class CreateWeekScheduleViewModel : IMapFrom<WeekSchedule>
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WeekStart { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WeekEnd { get; set; }
    }
}