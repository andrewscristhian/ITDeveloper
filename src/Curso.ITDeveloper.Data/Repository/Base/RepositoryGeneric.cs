using Curso.ITDeveloper.Data.ORM;
using Curso.ITDeveloper.DomainCore.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Curso.ITDeveloper.Data.Repository.Base
{
    public abstract class RepositoryGeneric<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, new()
    {
        protected ITDeveloperDbContext _context;

        protected RepositoryGeneric(ITDeveloperDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<TEntity>> SelecionarTodos(Expression<Func<TEntity, bool>> quando = null)
        {
            if (quando == null)
            {
                return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            return await _context.Set<TEntity>().AsNoTracking().Where(quando).ToListAsync();
        }

        public async Task<TEntity> SelecionarPorId(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        // Usar o virtual permite a sobrecarga do método (polimorfismo, mudar comportamento método)
        public virtual async Task Inserir(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            await SaveAsync();
        }

        public virtual async Task Atualizar(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await SaveAsync();
        }

        public virtual async Task Excluir(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            await SaveAsync();
        }

        public virtual async Task ExcluirPorId(TKey id)
        {
            // Usando o new, não precisa buscar o Id no BD para depois excluir
            //this._context.Set<TEntity>().Remove(new TEntity { Id = id }); -> aula 189, 12:30

            TEntity obj = await SelecionarPorId(id);
            await Excluir(obj);
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
    }
}
