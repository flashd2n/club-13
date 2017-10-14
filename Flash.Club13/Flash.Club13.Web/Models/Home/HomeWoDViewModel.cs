using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Automapper;
using System.Collections.Generic;

namespace Flash.Club13.Web.Models.Home
{
    public class HomeWoDViewModel : IMapFrom<WorkoutInformation>
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}