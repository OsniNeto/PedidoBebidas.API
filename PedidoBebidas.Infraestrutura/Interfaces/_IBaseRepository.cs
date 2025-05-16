using PedidoBebidas.Dominio.Entidades;

namespace PedidoBebidas.Infraestrutura.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntidade
    {
        Task<IEnumerable<TEntity>> ListarTodasAsync(List<string>? includes = null);
        Task<TEntity?> ObterPorIdAsync(Guid id, List<string>? includes = null);
        Task AdicionarAsync(TEntity entity);
        Task AtualizarAsync(TEntity entity);
        Task RemoverAsync(TEntity entity);
    }
}