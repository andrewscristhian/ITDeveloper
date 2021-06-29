using System.Collections.Generic;
using Curso.ITDeveloper.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Curso.ITDeveloper.Domain.Entities
{
    public class EstadoPaciente: EntityBase
    {
        [Display(Name = "Descricao")]
        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [StringLength(maximumLength:20, ErrorMessage = "O campo {0} deve ter entre {2} e {0} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        public virtual ICollection<Paciente> Paciente { get; set; }
    }
}
