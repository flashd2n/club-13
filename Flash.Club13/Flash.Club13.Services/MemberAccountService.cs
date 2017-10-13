using Flash.Club13.Data;
using Flash.Club13.Models;

namespace Flash.Club13.Services
{
    public class MemberAccountService
    {
        private MainDbContext dbContext;

        public MemberAccountService(MainDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateMemberAccount(Member member)
        {
            this.dbContext.Members.Add(member);
            this.dbContext.SaveChanges();
        }
    }
}
