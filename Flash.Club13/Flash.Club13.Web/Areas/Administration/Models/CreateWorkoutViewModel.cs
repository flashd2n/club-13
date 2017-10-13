using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;

namespace Flash.Club13.Web.Areas.Administration.Models
{
    public class CreateWorkoutViewModel : IMapFrom<WorkoutInformation>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string VideoLink { get; set; }

        public IList<ExerciseMutipleSelectionViewModel> AllExercises { get; set; }
    }
}