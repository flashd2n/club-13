using Flash.Club13.Models;
using System.Collections.Generic;

namespace Flash.Club13.Web.Areas.Administration.Models.Schedule
{
    public class AllSchedulesViewModel
    {
        public ICollection<ScheduleViewModel> Schedules { get; set; }
    }
}