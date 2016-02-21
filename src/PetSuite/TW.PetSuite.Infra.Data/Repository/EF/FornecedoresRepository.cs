using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.PetSuite.Domain.Entities.Fornecedores;
using TW.PetSuite.Infra.Data.Context;
using TW.PetSuite.Domain.Interfaces.Repository.EF;

namespace TW.PetSuite.Infra.Data.Repository.EF
{
    public class FornecedoresRepository : BaseRepository<Fornecedores, PetSuiteContext>, IFornecedorRepository
    {
        //Implementar a Buscar com filtro(código ou descrição).
    }
}
