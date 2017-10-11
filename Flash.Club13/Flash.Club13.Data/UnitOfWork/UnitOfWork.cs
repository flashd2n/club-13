using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash.Club13.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainDbContext context;

        public UnitOfWork(MainDbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
