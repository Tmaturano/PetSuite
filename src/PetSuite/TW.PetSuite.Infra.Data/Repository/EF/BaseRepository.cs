using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.PetSuite.Domain.Interfaces.Repository.EF;
using TW.PetSuite.Infra.Data.Interfaces;
using TW.PetSuite.Infra.Data.Context;
using Microsoft.Practices.ServiceLocation;
using System.Data.Entity;

namespace TW.PetSuite.Infra.Data.Repository.EF
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class
        where TContext : IDbContext, new()        
    {
        private readonly ContextManager<TContext> _contextManager = ServiceLocator.Current.GetInstance<IContextManager<TContext>>() as ContextManager<TContext>;
        private IDbSet<TEntity> _dbSet;
        private readonly IDbContext _dbContext;        

        public BaseRepository()
        {
            _dbContext = _contextManager.GetContext();
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity obj)
        {
            _dbSet.Add(obj);            
        }

        public virtual void Alterar(TEntity obj)
        {
            var entry = _dbContext.Entry(obj);
            _dbSet.Attach(obj);
            entry.State = EntityState.Modified;            
        }

        //Mudar para Id
        public virtual void Excluir(TEntity obj)
        {
            //var entry = _dbContext.Entry(obj);
            //if (entry.State == EntityState.Detached)
            //    _dbSet.Attach(obj);

            //dando erro aqui. 
            //_dbContext.Entry(obj).State = EntityState.Deleted;
            
            //Testar isso aqui
            //if (context.Entry(entityToDelete).State == EntityState.Detached)
            //{
                //dbSet.Attach(entityToDelete);
            //}
            //dbSet.Remove(entityToDelete);

            if (_dbSet.Local.First() != null)            
                _dbSet.Remove(_dbSet.Local.First());            
            else            
                _dbSet.Remove(obj);            
        }

        public virtual TEntity BuscarPorId(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> BuscarTodos()
        {
            return _dbSet.ToList();
        }        

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
