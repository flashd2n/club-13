using Flash.Club13.Models.Abstracts;

namespace Flash.Club13.Models
{
    public class PendingWorkout : DataModel
    {
        public virtual DailyWorkout DailyWorkout { get; set; }
        public virtual Member Member { get; set; }
        public virtual bool IsCompleted { get; set; }
    }
}
