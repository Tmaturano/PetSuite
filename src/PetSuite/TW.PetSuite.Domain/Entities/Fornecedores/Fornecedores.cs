using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.PetSuite.Domain.Validation;

namespace TW.PetSuite.Domain.Entities.Fornecedores
{
    public class Fornecedores
    {
        public Fornecedores()
        {
            FornecedorId = Guid.NewGuid();
        }

        public Guid FornecedorId { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }        
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Produtos.Produtos> Produtos { get; set; }

        public void ConferirContato(string contato1, string contato2)
        {
            AssertionConcern.AssertArgumentNotEquals(contato1, contato2, "Os telefones não podem ser iguais.");
            AssertionConcern.AssertArgumentLength(contato1, 15, "O Telefone deve ter no máximo 15 caracteres.");
            AssertionConcern.AssertArgumentLength(contato2, 15, "O Telefone deve ter no máximo 15 caracteres.");

            this.Telefone1 = contato1;
            this.Telefone2 = contato2;
        }
    }
}
