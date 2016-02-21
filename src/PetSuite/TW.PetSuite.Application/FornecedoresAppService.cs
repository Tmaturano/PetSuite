using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.PetSuite.Application.Interfaces;
using TW.PetSuite.Application.ViewModels;
using TW.PetSuite.Domain.Interfaces.Services;
using TW.PetSuite.Infra.Data.Context;
using TW.PetSuite.Domain.Entities.Fornecedores;
using TW.PetSuite.Domain.Specification;

namespace TW.PetSuite.Application
{
    public class FornecedoresAppService : AppServiceBase<PetSuiteContext>, IFornecedoresAppService
    {
        private readonly IFornecedoresService _fornecedorService;
        private string _mensagemRetorno = String.Empty;

        public FornecedoresAppService(IFornecedoresService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }       

        public string Adicionar(FornecedorViewModel fornecedorViewModel)
        {            
            var fornecedor = Mapper.Map<FornecedorViewModel, Fornecedores>(fornecedorViewModel);
            fornecedor.ConferirContato(fornecedor.Telefone1, fornecedor.Telefone2);

            BeginTransaction();            
            _fornecedorService.Adicionar(fornecedor);
            _mensagemRetorno = Commit();

            if (!String.IsNullOrEmpty(_mensagemRetorno))
            {
                return _mensagemRetorno;
            }
            else
                return _mensagemRetorno = String.Format("O fornecedor <strong>{0}</strong> foi inserido com sucesso.", fornecedorViewModel.Nome);
        }

        public string Alterar(FornecedorViewModel fornecedorViewModel)
        {
            var fornecedor = Mapper.Map<FornecedorViewModel, Fornecedores>(fornecedorViewModel);
            BeginTransaction();
            _fornecedorService.Alterar(fornecedor);
            _mensagemRetorno = Commit();

            if (!String.IsNullOrEmpty(_mensagemRetorno))
            {
                return _mensagemRetorno;
            }
            else
            {
                return _mensagemRetorno = String.Format("O fornecedor <strong>{0} - {1}</strong> foi alterado com sucesso.", fornecedorViewModel.Codigo, fornecedorViewModel.Nome);
            }
        }

        public string Excluir(FornecedorViewModel fornecedorViewModel)
        {
            var fornecedor = Mapper.Map<FornecedorViewModel, Fornecedores>(fornecedorViewModel);
            BeginTransaction();
            _fornecedorService.Excluir(fornecedor);
            _mensagemRetorno = Commit();            

            if (!String.IsNullOrEmpty(_mensagemRetorno))
            {
                return _mensagemRetorno;
            }
            else
            {
                return _mensagemRetorno = String.Format("O fornecedor <strong>{0} - {1}</strong> foi excluído com sucesso.", fornecedorViewModel.Codigo, fornecedorViewModel.Nome);
            }
        } 

        public ViewModels.FornecedorViewModel BuscarPorId(Guid id)
        {            
            return Mapper.Map<Fornecedores, FornecedorViewModel>(_fornecedorService.BuscarPorId(id));
        }

        public IEnumerable<FornecedorViewModel> BuscarTodos()
        {   
            return Mapper.Map<IEnumerable<Fornecedores>, IEnumerable<FornecedorViewModel>>(_fornecedorService.BuscarTodos());            
        }        
    }
}
