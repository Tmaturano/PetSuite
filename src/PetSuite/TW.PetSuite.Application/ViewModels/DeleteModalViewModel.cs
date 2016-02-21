using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TW.PetSuite.Application.ViewModels
{
    public class DeleteModalViewModel
    {
        [Display(Name="Descrição")]
        public string Descricao { get; set; }

        public string Tipo { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Guid Identificador { get; set; }        
    }
    
}
