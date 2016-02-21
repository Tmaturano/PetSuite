using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.PetSuite.Application.ViewModels;
using TW.PetSuite.Domain.Specification;

namespace TW.PetSuite.Application.Interfaces
{
    public interface IFornecedoresAppService
    {
        string Adicionar(FornecedorViewModel fornecedorViewModel);        
        string Alterar(FornecedorViewModel fornecedorViewModel);
        string Excluir(FornecedorViewModel fornecedorViewModel);
        FornecedorViewModel BuscarPorId(Guid id);
        IEnumerable<FornecedorViewModel> BuscarTodos();
    }
}
