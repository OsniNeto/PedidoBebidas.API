using PedidoBebidas.Aplicacao.DTOs;

namespace PedidoBebidas.Aplicacao.Interfaces
{
    public interface IRevendaService
    {
        Task<IEnumerable<RevendaDTO_Out>> ListarTodasAsync();
        Task<RevendaDTO_Out> ObterPorIdAsync(Guid id);
        Task<RevendaDTO_Out> CriarAsync(RevendaDTO_In dto);
        Task<RevendaDTO_Out?> AtualizarAsync(Guid id, RevendaDTO_In dto);
        Task<bool> RemoverAsync(Guid id);
    }
}