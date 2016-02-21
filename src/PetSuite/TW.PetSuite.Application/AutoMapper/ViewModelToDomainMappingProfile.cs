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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        /// <summary>
        /// Criação do mapeamento entre o ViewModel e o Model de domínio.
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<FornecedorViewModel, Fornecedores>();
        }
    }
}
