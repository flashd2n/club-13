using Flash.Club13.Models;
using Flash.Club13.Models.Enums;
using Flash.Club13.Web.Infrastructure.Automapper;
using System;

namespace Flash.Club13.Web.Models.Home
{
    public class HomeDailyWoDViewModel : IMapFrom<DailyWorkout>
    {
        public Guid Id { get; set; }

        public TimeOfDay StartTime { get; set; }
    }
}