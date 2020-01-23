using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Curso.ITDeveloper.Mvc.Extensions.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [StringLength(maximumLength:35, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres",
            MinimumLength = 2)]
        public string Apelido { get; set; }

        [PersonalData]
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [StringLength(maximumLength: 80, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres",
            MinimumLength = 2)]
        public string NomeCompleto { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
