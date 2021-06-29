using Curso.ITDeveloper.Domain.Entities;
using Curso.ITDeveloper.DomainCore.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Curso.ITDeveloper.Domain.Interfaces.Repository
{
    /* Interface especializada. Além dos métodos assinados no IDomainGenericRepository, também tem
     assinatura do método específico para a entidade */
    public interface IRepositoryPaciente : IRepository<Paciente, Guid>
    {
        Task<IEnumerable<Paciente>> ListaPacientesComEstado();
        Task<IEnumerable<Paciente>> ListaPacientes();
        List<EstadoPaciente> ListaEstadoPaciente();
        Task<Paciente> ObterPacienteComEstadoPaciente(Guid pacienteId);
        Task<IEnumerable<Paciente>> ObterPacientesPorEstadoPaciente(Guid estadoPacienteId);
        bool TemPaciente(Guid pacienteId);
    }
}
