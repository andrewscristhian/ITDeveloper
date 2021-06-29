using Curso.ITDeveloper.Data.ORM;
using Curso.ITDeveloper.Data.Repository.Base;
using Curso.ITDeveloper.Domain.Entities;
using Curso.ITDeveloper.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.ITDeveloper.Data.Repository
{
    public class PacienteRepository : RepositoryGeneric<Paciente, Guid>, IRepositoryPaciente
    {
        public PacienteRepository(ITDeveloperDbContext ctx) : base(ctx) => _context = ctx;

        // O arrow function substitui o {} e o return do método
        public async Task<IEnumerable<Paciente>> ListaPacientes() => await _context.Paciente.AsNoTracking().ToArrayAsync();

        public async Task<IEnumerable<Paciente>> ListaPacientesComEstado() => await _context.Paciente.Include(e => e.EstadoPaciente).AsNoTracking().ToListAsync();

        public List<EstadoPaciente> ListaEstadoPaciente() => _context.EstadoPaciente.AsNoTracking().ToListAsync().Result;

        public async Task<Paciente> ObterPacienteComEstadoPaciente(Guid pacienteId) => await _context.Paciente.Include(e => e.EstadoPaciente).AsNoTracking().FirstOrDefaultAsync(x => x.Id == pacienteId);

        public bool TemPaciente(Guid pacienteId) => _context.Paciente.Any(x => x.Id == pacienteId);

        public async Task<IEnumerable<Paciente>> ObterPacientesPorEstadoPaciente(Guid estadoPacienteId)
        {
            var lista = await _context.Paciente
                .Include(ep => ep.EstadoPaciente)
                .AsNoTracking()
                .Where(x => x.EstadoPaciente.Id == estadoPacienteId)
                .OrderBy(order => order.Nome).ToListAsync();

            return lista;
        }
    }
}
