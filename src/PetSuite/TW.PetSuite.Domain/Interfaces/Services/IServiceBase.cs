using System;
using System.Collections.Generic;

namespace TW.PetSuite.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        void Alterar(TEntity obj);
        void Excluir(TEntity obj);
        TEntity BuscarPorId(Guid id);
        IEnumerable<TEntity> BuscarTodos();        
        void Dispose();
    }
}
