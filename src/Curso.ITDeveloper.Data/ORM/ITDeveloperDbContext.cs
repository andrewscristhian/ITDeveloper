using Curso.ITDeveloper.Domain.Entities;
using Curso.ITDeveloper.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Curso.ITDeveloper.Data.ORM
{
    // Responsavel por fazer o link entre o Model e o Banco de Dados
    public class ITDeveloperDbContext : DbContext
    {
        public ITDeveloperDbContext(DbContextOptions<ITDeveloperDbContext> options)
            : base(options)
        { }

        //Gerar tabela Mural no BD
        public DbSet<Mural> Mural { get; set; }

        //Gerar tabela Paciente no BD
        public DbSet<Paciente> Paciente { get; set; }

        //Gerar tabela EstadoPaciente no BD
        public DbSet<EstadoPaciente> EstadoPaciente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // onde não tiver setado varchar e a propriedade for do tipo string fica valendo varchar(100)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(90)");
            }

            //modelBuilder.ApplyConfiguration(new EstadoPacienteMap());
            //modelBuilder.ApplyConfiguration(new PacienteMap());

            // Impl033: Busca os Mapppings de uma vez só
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ITDeveloperDbContext).Assembly);

            //remover delete cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);

        }
    }
}
