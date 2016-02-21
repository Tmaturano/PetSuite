using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.PetSuite.Domain.Entities.Fornecedores;
using TW.PetSuite.Domain.Interfaces.Services;
using TW.PetSuite.Domain.Interfaces.Repository.EF;

namespace TW.PetSuite.Domain.Services
{
    public class FornecedoresService : ServiceBase<Fornecedores>, IFornecedoresService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedoresService(IFornecedorRepository fornecedorRepository) : base(fornecedorRepository)
        {
            this._fornecedorRepository = fornecedorRepository;
        }

        //
           
    }
}
