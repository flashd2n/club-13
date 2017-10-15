using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Flash.Club13.Web.Areas.Administration.Models.Schedule
{
    public class DailyWorkoutViewModel : IMapFrom<DailyWorkout>, IHaveCustomMappings
    {
        public string Day { get; set; }

        [Required]
        [Range(0, 60)]
        public int DurationInMinutes { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid ScheduleId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<DailyWorkout, DailyWorkoutViewModel>()
                .ForMember(x => x.Name, cfg => cfg.MapFrom(y => y.WorkoutInformation.Name));
        }
    }
}