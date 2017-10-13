using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Automapper;

namespace Flash.Club13.Web.Areas.Administration.Models
{
    public class CreateExerciseViewModel : IMapFrom<Exercise>
    {
        public string Name { get; set; }
    }
}