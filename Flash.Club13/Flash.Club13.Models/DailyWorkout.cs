using Flash.Club13.Models.Abstracts;
using Flash.Club13.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flash.Club13.Models
{
    public class DailyWorkout : DataModel
    {
        private ICollection<Member> signedMembers;

        public DailyWorkout()
        {
            this.signedMembers = new HashSet<Member>();
        }

        public string Day { get; set; }

        public TimeOfDay StartTime { get; set; }

        public int DurationInMinutes { get; set; }

        [ForeignKey("WorkoutInformation")]
        public Guid WorkoutInformationId { get; set; }

        public virtual WorkoutInformation WorkoutInformation { get; set; }

        public virtual ICollection<Member> SignedMembers
        {
            get { return this.signedMembers; }
            set { this.signedMembers = value; }
        }
    }
}
