using Curso.ITDeveloper.Application.ViewModels;
using Curso.ITDeveloper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Curso.ITDeveloper.Application.Interfaces
{
    public interface IServicoAplicacaoPaciente
    {
        /* Queries */
        Task<IEnumerable<PacienteViewModel>> ObterPacientesComEstadoPacienteApplication();
        Task<IEnumerable<PacienteViewModel>> ObterPacientesDePacienteViewModelApplication();
        Task<PacienteViewModel> ObterPacienteComEstadoPacienteApplication(Guid pacienteId);
        Task<IEnumerable<PacienteViewModel>> ObterPacientesPorEstadoPacienteApplication(Guid estadoPacienteId);
        Task<List<EstadoPaciente>> ListaEstadoPacienteApplication();
        bool TemPacienteApplication(Guid pacienteId);


        /* Commands */
    }
}