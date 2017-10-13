using Flash.Club13.Models.Abstracts;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flash.Club13.Models
{
    public class Workout : DataModel
    {
        [ForeignKey("Member")]
        public Guid MemberId { get; set; }

        public virtual Member Member { get; set; }

        [ForeignKey("WorkoutInformation")]
        public Guid WorkoutInformationId { get; set; }

        public virtual WorkoutInformation WorkoutInformation { get; set; }

        public TimeSpan? Time { get; set; }
    }
}
