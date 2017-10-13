using Flash.Club13.Models.Abstracts;
using Flash.Club13.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flash.Club13.Models
{
    public class Member : DataModel
    {
        private ICollection<Workout> workouts;

        public Member()
        {
            this.workouts = new HashSet<Workout>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public ICollection<Workout> Workouts
        {
            get { return this.workouts; }
            set { this.workouts = value; }
        }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

    }
}
