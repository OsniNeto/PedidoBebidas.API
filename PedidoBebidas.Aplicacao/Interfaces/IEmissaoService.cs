using PedidoBebidas.Aplicacao.DTOs;

namespace PedidoBebidas.Aplicacao.Interfaces
{
    public interface IEmissaoService
    {
        Task<IEnumerable<EmissaoDTO_Out>> ListarTodasAsync();
        Task<EmissaoDTO_Out> ObterPorIdAsync(Guid id);
        Task<EmissaoDTO_Out> CriarAsync(EmissaoDTO_In dto);
        Task<EmissaoDTO_Out?> AtualizarAsync(Guid id, EmissaoDTO_In dto);
        Task<bool> RemoverAsync(Guid id);
        Task<EmissaoTentativaEnvioDTO_Out> EnviarAsync(Guid id);
        Task<EmissaoTentativaEnvioDTO_Out> ObterTentativasPorIdAsync(Guid id);
    }
}