using Flash.Club13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash.Club13.Interfaces.Services
{
    public interface IPendingWorkoutService
    {
        ICollection<PendingWorkout> GetAll();

        PendingWorkout GetById(Guid id);

        void Update(PendingWorkout pendingWorkout);

        void AddPending(PendingWorkout pendingWorkout);

        void MarkPendingAsCompleted(PendingWorkout pendingWorkout);
    }
}
