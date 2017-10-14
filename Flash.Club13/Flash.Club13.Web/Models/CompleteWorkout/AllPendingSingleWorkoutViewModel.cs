using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Flash.Club13.Web.Models.CompleteWorkout
{
    public class AllPendingSingleWorkoutViewModel : IMapFrom<PendingWorkout>, IHaveCustomMappings
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PendingWorkout, AllPendingSingleWorkoutViewModel>()
                .ForMember(x => x.Name, cfg => cfg.MapFrom(y => y.DailyWorkout.WorkoutInformation.Name));
        }
    }
}