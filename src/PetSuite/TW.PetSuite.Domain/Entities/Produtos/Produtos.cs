using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.PetSuite.Domain.Entities.Fornecedores;

namespace TW.PetSuite.Domain.Entities.Produtos
{
    public class Produtos
    {
        public Produtos()
        {
            ProdutoId = Guid.NewGuid();
        }

        public Guid ProdutoId { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int? Quantidade { get; set; }
        public Guid? FornecedorId { get; set; }
        public virtual Fornecedores.Fornecedores Fornecedores { get; set; }
    }
}
