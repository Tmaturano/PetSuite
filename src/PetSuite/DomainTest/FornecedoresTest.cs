using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TW.PetSuite.Domain.Entities.Fornecedores;

namespace DomainTest
{
    [TestClass]
    public class FornecedoresTest
    {
        [TestMethod]
        [TestCategory("Novo Fornecedor")]//ajuda na visualização do teste
        public void Novo_Fornecedor()
        {
            var fornecedores = new Fornecedores();
            fornecedores.Nome = "Fulano";
            fornecedores.Telefone1 = "99082216";
            fornecedores.Telefone2 = "11111111";
            fornecedores.Email = "teste@teste.com";
            fornecedores.Codigo = 10;

            //Assert.AreEqual(10, fornecedores.Codigo);
            Assert.IsNotNull(fornecedores);

        }
    }
}
