using PedidoBebidas.Dominio.Entidades;

namespace PedidoBebidas.Infraestrutura.Interfaces
{
    public interface IEmissaoRepository : IBaseRepository<Emissao>
    {
        Task<Emissao> AdicionarAsync(List<Guid> idsPedidos);
        Task<Emissao> AtualizarAsync(Guid id, List<Guid> idsPedidos);
        Task SetarEnviadoAsync(Guid id, bool sucesso);
    }
}
