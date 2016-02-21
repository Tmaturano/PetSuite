using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.PetSuite.Application.Interfaces;
using TW.PetSuite.Infra.Data.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace TW.PetSuite.Application
{
    public class AppServiceBase<TContext> : IAppServiceBase<TContext> where TContext : IDbContext, new()
    {
        private IUnitOfWork<TContext> _uow;
        
        public void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork<TContext>>();
            _uow.BeginTransaction();            
        }

        public string Commit()
        {
            return _uow.SaveChanges();
        }
    }
}
