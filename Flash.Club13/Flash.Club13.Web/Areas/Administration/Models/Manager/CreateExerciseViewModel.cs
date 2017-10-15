using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Automapper;
using System.ComponentModel.DataAnnotations;

namespace Flash.Club13.Web.Areas.Administration.Models
{
    public class CreateExerciseViewModel : IMapFrom<Exercise>
    {
        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 5)]
        public string Name { get; set; }
    }
}