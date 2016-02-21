using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.PetSuite.Infra.Data.Context;
using TW.PetSuite.Infra.Data.Interfaces;

namespace TW.PetSuite.Infra.Data.UoW
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : IDbContext, new()
    {
        private readonly IDbContext _dbContext;
        private readonly ContextManager<TContext> _contextManager = ServiceLocator.Current.GetInstance<IContextManager<TContext>>() as ContextManager<TContext>;
        private string _mensagemRetorno = String.Empty;

        private bool _disposed;

        public UnitOfWork()
        {
            _dbContext = _contextManager.GetContext();
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public string SaveChanges()
        {
            bool saveFailed;

            do
            {
                saveFailed = false;

                try
                {
                    _dbContext.SaveChanges();
                    Dispose();
                }
                catch (DbUpdateConcurrencyException dbEx)
                {
                    //Método Client Wins
                    //Desta forma, sobreescrevo o que estava no BD com o que o usuário acaba de inserir(ou seja, o último sempre ganha)
                    //entry.OriginalValues.SetValues(entry.GetDatabaseValues());


                    //Metodo Store Wins
                    //Desta forma, caso aconteça alguma exception de concorrência na hora de inserir no BD, gravo o que já estava no BD(ou seja, sem a alteração do usuário)

                    saveFailed = true;
                    dbEx.Entries.Single().Reload();
                    _mensagemRetorno = "Erro: A ação não foi executada, pois algum outro usuário já manipulou as informações deste produto. Por favor, atualize a página.";
                }    
            } while (saveFailed);

            return _mensagemRetorno;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
