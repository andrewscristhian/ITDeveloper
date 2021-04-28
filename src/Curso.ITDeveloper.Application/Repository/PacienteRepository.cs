using Curso.ITDeveloper.Data.ORM;
using Curso.ITDeveloper.Domain.Interfaces.Repository;
using Curso.ITDeveloper.Domain.Models;
using Curso.ITDeveloper.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.ITDeveloper.Application.Repository
{
    public class PacienteRepository : RepositoryGeneric<Paciente, Guid>, IPacienteRepository
    {
        private readonly ITDeveloperDbContext _ctx;

        public PacienteRepository(ITDeveloperDbContext ctx) : base(ctx) => _ctx = ctx;

        // O arrow function substitui o {} e o return do método
        public async Task<IEnumerable<Paciente>> ListaPacientes() => await _ctx.Paciente.AsNoTracking().ToArrayAsync();

        public async Task<IEnumerable<Paciente>> ListaPacientesComEstado() => await _ctx.Paciente.Include(e => e.EstadoPaciente).AsNoTracking().ToListAsync();

        public List<EstadoPaciente> ListaEstadoPaciente() => _ctx.EstadoPaciente.AsNoTracking().ToListAsync().Result;

        public async Task<Paciente> ObterPacienteComEstadoPaciente(Guid pacienteId) => await _ctx.Paciente.Include(e => e.EstadoPaciente).AsNoTracking().FirstOrDefaultAsync(x => x.Id == pacienteId);

        public bool TemPaciente(Guid pacienteId) => _ctx.Paciente.Any(x => x.Id == pacienteId);

        public async Task<IEnumerable<Paciente>> ObterPacientesPorEstadoPaciente(Guid estadoPacienteId)
        {
            var lista = await _ctx.Paciente
                .Include(ep => ep.EstadoPaciente)
                .AsNoTracking()
                .Where(x => x.EstadoPaciente.Id == estadoPacienteId)
                .OrderBy(order => order.Nome).ToListAsync();

            return lista;
        }
    }
}
