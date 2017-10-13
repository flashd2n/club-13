﻿using Flash.Club13.Models.Abstracts;
using Flash.Club13.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flash.Club13.Models
{
    public class Member : DataModel
    {
        private ICollection<Workout> workouts;
        private ICollection<DailyWorkout> dailyWorkouts;

        public Member()
        {
            this.workouts = new HashSet<Workout>();
            this.dailyWorkouts = new HashSet<DailyWorkout>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public virtual ICollection<Workout> Workouts
        {
            get { return this.workouts; }
            set { this.workouts = value; }
        }

        public virtual ICollection<DailyWorkout> DailyWorkouts
        {
            get { return this.dailyWorkouts; }
            set { this.dailyWorkouts = value; }
        }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

    }
}
