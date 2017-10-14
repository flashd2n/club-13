using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flash.Club13.Web.Areas.Administration.Models
{
    public class ExerciseMutipleSelectionViewModel : IMapFrom<Exercise>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}