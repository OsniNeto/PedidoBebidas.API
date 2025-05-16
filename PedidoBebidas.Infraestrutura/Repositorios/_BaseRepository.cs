using Microsoft.EntityFrameworkCore;
using PedidoBebidas.Dominio.Entidades;
using PedidoBebidas.Infraestrutura.Persistencia;
using System.Linq.Expressions;

namespace PedidoBebidas.Infraestrutura.Repositorios
{
    public class BaseRepository<T>(AppDbContext _context) where T : BaseEntidade
    {
        public async Task<IEnumerable<T>> ListarTodasAsync(List<string>? includes = null)
        {
            var query = _context.Set<T>().AsNoTracking();

            if (includes != null && includes.Count != 0)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }

        public virtual async Task<T?> ObterPorIdAsync(Guid id, List<string>? includes = null)
        {
            var query = _context.Set<T>().AsQueryable();

            if (includes != null && includes.Count != 0)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task AdicionarAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task AtualizarAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
