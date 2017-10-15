using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flash.Club13.Web.Models.CompleteWorkout
{
    public class CompleteViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(minimum: 0, maximum: 60, ErrorMessage = "Minutes must be between 0 and 60")]
        public int Minutes { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(minimum: 0, maximum: 60, ErrorMessage = "Seconds must be between 0 and 60")]
        public int Seconds { get; set; }
    }
}