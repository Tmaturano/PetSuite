using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TW.PetSuite.Application.ViewModels
{
    public class FornecedorViewModel
    {
        public FornecedorViewModel()
        {
            FornecedorId = Guid.NewGuid();
        }

        [Key]
        public Guid FornecedorId { get; set; }

        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        public string Nome { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo {0} dígitos")]
        [Display(Name = "Telefone")]
        public string Telefone1 { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo {0} dígitos")]
        [Display(Name = "Telefone 2")]
        public string Telefone2 { get; set; }
                
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        public string Email { get; set; }
                        
    }
}
