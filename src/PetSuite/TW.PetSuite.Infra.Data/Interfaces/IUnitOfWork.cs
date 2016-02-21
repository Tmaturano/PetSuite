using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TW.PetSuite.Infra.Data.Interfaces
{
    public interface IUnitOfWork<TContext> where TContext : IDbContext, new()
    {
        void BeginTransaction();
        string SaveChanges();
    }
}
