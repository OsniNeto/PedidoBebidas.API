using PedidoBebidas.Aplicacao.DTOs;

namespace PedidoBebidas.Aplicacao.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoDTO_Out>> ListarTodasAsync();
        Task<IEnumerable<PedidoDTO_Out>> ListarNaoEmitidosAsync();
        Task<PedidoDTO_Out> ObterPorIdAsync(Guid id);
        Task<PedidoDTO_Out> CriarAsync(PedidoDTO_In dto);
        Task<PedidoDTO_Out?> AtualizarAsync(Guid id, PedidoDTO_In dto);
        Task<bool> RemoverAsync(Guid id);
    }
}