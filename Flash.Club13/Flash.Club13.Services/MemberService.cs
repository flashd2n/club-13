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
            this.membersRepo = membersRepo ?? throw new ArgumentException("Members repo cannot be null");
            this.unitOfWork = unitOfWork ?? throw new ArgumentException("Unit of work cannot be null");
        }

        public Member GetByUserId(string id)
        {
            if (id == null)
            {
                throw new ArgumentException("Provided Id is not valid");
            }

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
            if (member == null)
            {
                throw new ArgumentException("Member cannot be null");
            }

            this.membersRepo.Update(member);
            this.unitOfWork.Commit();
        }

        public void AddPending(Member member, PendingWorkout workout)
        {
            if (member == null)
            {
                throw new ArgumentException("Member cannot be null");
            }

            if (workout == null)
            {
                throw new ArgumentException("Workout cannot be null");
            }

            member.PendingWorkouts.Add(workout);
            this.Update(member);
        }

        public void AddWorkout(Member member, Workout workout)
        {
            if (member == null)
            {
                throw new ArgumentException("Member cannot be null");
            }

            if (workout == null)
            {
                throw new ArgumentException("Workout cannot be null");
            }

            member.Workouts.Add(workout);
            this.Update(member);
        }
    }
}
