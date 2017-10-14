using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flash.Club13.Web.Models.CompleteWorkout
{
    public class CompleteViewModel
    {
        public Guid Id { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
    }
}