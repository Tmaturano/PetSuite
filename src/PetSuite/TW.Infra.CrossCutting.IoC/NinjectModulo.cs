using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using TW.PetSuite.Infra.Data.Interfaces;
using TW.PetSuite.Infra.Data.Repository;
using TW.PetSuite.Infra.Data.Context;
using TW.PetSuite.Infra.Data.UoW;
using TW.PetSuite.Domain.Interfaces.Repository.EF;
using TW.PetSuite.Domain.Interfaces.Services;
using TW.PetSuite.Domain.Services;
using TW.PetSuite.Application.Interfaces;
using TW.PetSuite.Application;
using TW.PetSuite.Infra.Data.Repository.EF;


namespace TW.Infra.CrossCutting.IoC
{
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            //faz um new em memória e te dá a instância pronta. 
            //toda vez que precisar da interface, vai receber uma instance concreta da classe correspondente.
            //todo esse bind fica em memória.
            //cada classe ter sua propria interface, senão não é possível fazer DIP.


            //app
            Bind<IFornecedoresAppService>().To<FornecedoresAppService>();

            //service            
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IFornecedoresService>().To<FornecedoresService>();

            //data repos
            Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<,>));
            Bind<IFornecedorRepository>().To<FornecedoresRepository>();

            //data configs
            Bind(typeof(IContextManager<>)).To(typeof(ContextManager<>));
            Bind<IDbContext>().To<PetSuiteContext>();
            Bind(typeof(IUnitOfWork<>)).To(typeof(UnitOfWork<>));
        }
    }
}
