using AutoMapper;
using PedidoBebidas.Aplicacao.DTOs;
using PedidoBebidas.Aplicacao.Interfaces;
using PedidoBebidas.Dominio.Entidades;
using PedidoBebidas.Infraestrutura.Interfaces;

namespace PedidoBebidas.Aplicacao.Services
{
    public class RevendaService(IRevendaRepository _revendaRepository, IMapper _mapper) : IRevendaService
    {
        public async Task<IEnumerable<RevendaDTO_Out>> ListarTodasAsync()
        {
            var revendas = await _revendaRepository.ListarTodasAsync(["Telefones", "Contatos", "EnderecosEntrega"]);
            return _mapper.Map<IEnumerable<RevendaDTO_Out>>(revendas);
        }

        public async Task<RevendaDTO_Out> ObterPorIdAsync(Guid id)
        {
            var revenda = await _revendaRepository.ObterPorIdAsync(id, ["Telefones", "Contatos", "EnderecosEntrega"]);
            return _mapper.Map<RevendaDTO_Out>(revenda);
        }

        public async Task<RevendaDTO_Out> CriarAsync(RevendaDTO_In dto)
        {
            var revenda = _mapper.Map<Revenda>(dto);
            await _revendaRepository.AdicionarAsync(revenda);
            return _mapper.Map<RevendaDTO_Out>(revenda);
        }

        public async Task<RevendaDTO_Out?> AtualizarAsync(Guid id, RevendaDTO_In dto)
        {
            var revenda = _mapper.Map<Revenda>(dto);
            revenda.Id = id;

            await _revendaRepository.AtualizarAsync(revenda);
            return _mapper.Map<RevendaDTO_Out>(revenda);
        }

        public async Task<bool> RemoverAsync(Guid id)
        {
            var revenda = await _revendaRepository.ObterPorIdAsync(id);

            if (revenda != null)
                await _revendaRepository.RemoverAsync(revenda);

            return true;
        }

    }
}
