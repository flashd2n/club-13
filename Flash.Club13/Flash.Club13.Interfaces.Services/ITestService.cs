using Flash.Club13.Models;
using System.Linq;

namespace Flash.Club13.Interfaces.Services
{
    public interface ITestService
    {
        IQueryable<Test> GetAll();

        void Update(Test post);

        void AddTest(Test post);
    }
}
