using Flash.Club13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash.Club13.Interfaces.Services
{
    public interface IMemberService
    {
        Member GetByUserId(string id);

        Member GetById(Guid id);

        int GetTotalMemberCount();

        void Update(Member member);

        void AddPending(Member member, PendingWorkout workout);

        void AddWorkout(Member member, Workout workout);
    }
}
