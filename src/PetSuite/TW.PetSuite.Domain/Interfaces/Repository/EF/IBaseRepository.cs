using System;
using System.Collections.Generic;
using TW.PetSuite.Domain.Specification;

namespace TW.PetSuite.Domain.Interfaces.Repository.EF
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity obj);
        void Alterar(TEntity obj);
        void Excluir(TEntity obj);
        TEntity BuscarPorId(Guid id);
        IEnumerable<TEntity> BuscarTodos();        
    }
}
