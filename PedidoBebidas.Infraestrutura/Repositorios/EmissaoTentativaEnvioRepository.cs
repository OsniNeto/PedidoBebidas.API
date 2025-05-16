using Microsoft.EntityFrameworkCore;
using PedidoBebidas.Dominio.Entidades;
using PedidoBebidas.Infraestrutura.Interfaces;
using PedidoBebidas.Infraestrutura.Persistencia;

namespace PedidoBebidas.Infraestrutura.Repositorios
{
    public class EmissaoTentativaEnvioRepository(AppDbContext _context) : BaseRepository<EmissaoTentativaEnvio>(_context), IEmissaoTentativaEnvioRepository
    {
        public Task<List<EmissaoTentativaEnvio>> ObterPorEmissaoIdAsync(Guid id)
        {
            var query = _context.EmissaoTentativasEnvio.Where(x => x.EmissaoId == id).OrderBy(x => x.DataCriacao);

            return query.ToListAsync();
        }
    }
}