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
    }
}
