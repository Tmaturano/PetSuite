using System;
using System.Collections.Generic;
using TW.PetSuite.Domain.Interfaces.Services;
using TW.PetSuite.Domain.Interfaces.Repository.EF;

namespace TW.PetSuite.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        
        public ServiceBase(IBaseRepository<TEntity> repositorio)
        {
            this._repository = repositorio;
        }

        public void Adicionar(TEntity obj)
        {
            this._repository.Adicionar(obj);            
        }

        public void Alterar(TEntity obj)
        {
            this._repository.Alterar(obj);            
        }

        public void Excluir(TEntity obj)
        {
            this._repository.Excluir(obj);            
        }

        public TEntity BuscarPorId(Guid id)
        {
            return this._repository.BuscarPorId(id);
        }

        public IEnumerable<TEntity> BuscarTodos()
        {
            return this._repository.BuscarTodos();
        }
        
        public void Dispose()
        {
            this._repository.Dispose();
        }

    }
}
