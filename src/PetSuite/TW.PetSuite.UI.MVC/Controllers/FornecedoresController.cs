using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TW.PetSuite.Application.Interfaces;
using TW.PetSuite.Application.ViewModels;
using PagedList;

namespace TW.PetSuite.UI.MVC.Controllers
{
    /// <summary>
    /// TODO: Usar Async e Await para tornar as chamadas assíncronas.
    /// </summary>
    public class FornecedoresController : Controller
    {
        private readonly IFornecedoresAppService _fornecedorAppService;
        private const int _pageSize = 10;

        public FornecedoresController(IFornecedoresAppService fornecedorAppService)
        {
            _fornecedorAppService = fornecedorAppService;
        }

        // GET: Fornecedores
        public ActionResult Index()
        {            
            IEnumerable<FornecedorViewModel> fornecedoresViewModel = new List<FornecedorViewModel>();
            fornecedoresViewModel = _fornecedorAppService.BuscarTodos();
            var listaFornecedores = fornecedoresViewModel.ToList();

            return View(listaFornecedores);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Nome,Telefone1,Telefone2,Email")]FornecedorViewModel fornecedorViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["MensagemRetorno"] = _fornecedorAppService.Adicionar(fornecedorViewModel);
                    TempData["Erro"] = TempData["MensagemRetorno"].ToString().Contains("Erro") ? true : false;

                    return RedirectToAction("Index");
                }

                return View(fornecedorViewModel);
            }
            catch (Exception ex)
            {
                //Logar.
                //Alterar esse tipo de catch para continuar na página, apenas exibir o erro logo acima, para o usuário não
                //ter que digitar tudo novamente.
                //Mudar a classe AssertionConcern para o CrossCutting(pois essas validações podem ser usadas não só pelo domínio,
                //mas em outros lugares também.
                //Criar no CrossCutting, uma nova class library chamada Common e adicionar a pasta validations ali.
                TempData["MensagemRetorno"] = ex.Message;
                TempData["Erro"] = true;

                return RedirectToAction("Index");
            }            
        }

        public ActionResult Delete(Guid id)
        {
            var fornecedor = _fornecedorAppService.BuscarPorId(id);
            DeleteModalViewModel view = new DeleteModalViewModel();

            view.Action = "Delete";
            view.Controller = "Fornecedores";
            view.Descricao = String.Format("({0}) {1}", fornecedor.Codigo, fornecedor.Nome);
            view.Tipo = "Fornecedor";
            view.Identificador = fornecedor.FornecedorId;

            return PartialView("_Delete", view);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(DeleteModalViewModel view)
        {            
            try
            {
                FornecedorViewModel fornecedor = _fornecedorAppService.BuscarPorId(view.Identificador);
                //Antes de passar o objeto para o Excluir, pesquisar antes através do view.Identificador.
                TempData["MensagemRetorno"] = _fornecedorAppService.Excluir(fornecedor);
                //TempData["MensagemRetorno"] = _fornecedorAppService.Excluir(fornecedor);
                TempData["Erro"] = TempData["MensagemRetorno"].ToString().Contains("Erro") ? true : false;
                
            }
            catch (Exception ex)
            {
                TempData["MensagemRetorno"] = ex.ToString();
                TempData["Erro"] = true;                
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var fornecedorViewModel = _fornecedorAppService.BuscarPorId(id);

            return View(fornecedorViewModel);
        }


        //Usar o Bind Attribute e não deixar atualizar FornecedorId e Codigo
        //[Bind(Include="Nome,Telefone1,Telefone2,Email")] . Dá DbUpdateConcurrencyException...
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FornecedorViewModel fornecedorViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["MensagemRetorno"] = _fornecedorAppService.Alterar(fornecedorViewModel);
                    TempData["Erro"] = TempData["MensagemRetorno"].ToString().Contains("Erro") ? true : false;                    
                }
                else
                    return View(fornecedorViewModel);
            }
            catch (Exception ex)
            {
                //Logar.
                TempData["MensagemRetorno"] = ex.ToString();
                TempData["Erro"] = true;
            }

            return RedirectToAction("Index");
        }
    }
}