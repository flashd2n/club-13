using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Automapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Flash.Club13.Web.Infrastructure.Attributes;

namespace Flash.Club13.Web.Areas.Administration.Models
{
    public class CreateWorkoutViewModel : IMapFrom<WorkoutInformation>
    {
        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string VideoLink { get; set; }

        [ExerciseSelect]
        public IList<ExerciseMutipleSelectionViewModel> AllExercises { get; set; }
    }
}