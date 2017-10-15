using Flash.Club13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash.Club13.Web.Infrastructure.Factories
{
    public interface IDataModelFactory
    {
        Workout CreateWorkout();
        PendingWorkout CreatePendingWorkout(DailyWorkout dailyWorkout, Member member, bool isCompleted);
    }
}
