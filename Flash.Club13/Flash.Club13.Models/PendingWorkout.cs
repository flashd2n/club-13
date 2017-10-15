using Flash.Club13.Models.Abstracts;

namespace Flash.Club13.Models
{
    public class PendingWorkout : DataModel
    {
        public PendingWorkout()
        {
        }

        public PendingWorkout(DailyWorkout dailyWorkout, Member member, bool isCompleted)
        {
            this.DailyWorkout = dailyWorkout;
            this.Member = member;
            this.IsCompleted = isCompleted;
        }

        public virtual DailyWorkout DailyWorkout { get; set; }
        public virtual Member Member { get; set; }
        public virtual bool IsCompleted { get; set; }
    }
}
