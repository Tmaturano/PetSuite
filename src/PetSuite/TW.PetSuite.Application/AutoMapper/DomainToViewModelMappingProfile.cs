using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TW.PetSuite.Application.ViewModels;
using TW.PetSuite.Domain.Entities.Fornecedores;

namespace TW.PetSuite.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// DomainToViewModelMappingProfile > Profile de mapeamento (Model > View Model) 
        /// </summary>
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        /// <summary>
        /// Criação do mapeamento entre o Model de domínio e o ViewModel.
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<Fornecedores, FornecedorViewModel>();
        }
    }
}
