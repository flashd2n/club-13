using Flash.Club13.Data.Repository;
using Flash.Club13.Data.UnitOfWork;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash.Club13.Services
{
    public class MemberService : IMemberService
    {
        private readonly IEfRepostory<Member> membersRepo;
        private readonly IUnitOfWork unitOfWork;

        public MemberService(IEfRepostory<Member> membersRepo, IUnitOfWork unitOfWork)
        {
            this.membersRepo = membersRepo;
            this.unitOfWork = unitOfWork;
        }

        public Member GetByUserId(string id)
        {
            return this.membersRepo.All.FirstOrDefault(x => x.UserId == id);
        }

        public int GetTotalMemberCount()
        {
            return this.membersRepo.All.Count();
        }

        public Member GetById(Guid id)
        {
            return this.membersRepo.All.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Member member)
        {
            this.membersRepo.Update(member);
            this.unitOfWork.Commit();
        }

        public void AddPending(Member member, PendingWorkout workout)
        {
            member.PendingWorkouts.Add(workout);
            this.Update(member);
        }

        public void AddWorkout(Member member, Workout workout)
        {
            member.Workouts.Add(workout);
            this.Update(member);
        }
    }
}
