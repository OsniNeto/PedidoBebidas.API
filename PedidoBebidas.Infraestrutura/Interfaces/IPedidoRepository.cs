using PedidoBebidas.Dominio.Entidades;

namespace PedidoBebidas.Infraestrutura.Interfaces
{
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> ListarNaoEmitidosAsync(List<string>? includes = null);
    }
}
