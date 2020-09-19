﻿using Curso.ITDeveloper.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Curso.ITDeveloper.Domain.Models
{
    public class Cid : EntityBase
    {
        //CidAdaptadaId;Codigo;Diagnostico
        public Cid() { }

        [Display(Name = "Internal ID")]
        [Required(ErrorMessage = "Internal ID é obrigatório")]
        public int CidInternalId { get; set; }

        [Required(ErrorMessage = "Código é obrigatório")]
        [Display(Name = "Código")]
        [MaxLength(6)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Diagnóstico é obrigatório")]
        [Display(Name = "Diagnóstico")]
        [MaxLength(4000)]
        public string Diagnostico { get; set; }
    }
}
