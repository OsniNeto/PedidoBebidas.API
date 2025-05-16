using PedidoBebidas.Dominio.Entidades;

namespace PedidoBebidas.Infraestrutura.Interfaces
{
    public interface IEmissaoTentativaEnvioRepository : IBaseRepository<EmissaoTentativaEnvio>
    {
        Task<List<EmissaoTentativaEnvio>> ObterPorEmissaoIdAsync(Guid id);
    }
}
