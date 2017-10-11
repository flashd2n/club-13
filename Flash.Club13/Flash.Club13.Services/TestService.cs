using Flash.Club13.Data.Repository;
using Flash.Club13.Data.UnitOfWork;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using System.Linq;

namespace Flash.Club13.Services
{
    public class TestService : ITestService
    {
        private readonly IEfRepostory<Test> testRepo;
        private readonly IUnitOfWork unitOfWork;

        public TestService(IEfRepostory<Test> testRepo, IUnitOfWork unitOfWork)
        {
            this.testRepo = testRepo;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Test> GetAll()
        {
            return this.testRepo.All;
        }

        public void Update(Test post)
        {
            this.testRepo.Update(post);
            this.unitOfWork.Commit();
        }

        public void AddTest(Test post)
        {
            this.testRepo.Add(post);
            this.unitOfWork.Commit();
        }
    }
}
