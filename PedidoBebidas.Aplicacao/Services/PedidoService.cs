using AutoMapper;
using PedidoBebidas.Aplicacao.DTOs;
using PedidoBebidas.Aplicacao.Interfaces;
using PedidoBebidas.Dominio.Entidades;
using PedidoBebidas.Infraestrutura.Interfaces;

namespace PedidoBebidas.Aplicacao.Services
{
    public class PedidoService(IPedidoRepository _pedidoRepository, IMapper _mapper) : IPedidoService
    {
        public async Task<IEnumerable<PedidoDTO_Out>> ListarTodasAsync()
        {
            var pedidos = await _pedidoRepository.ListarTodasAsync(["PedidoProdutos", "Revenda"]);
            return _mapper.Map<IEnumerable<PedidoDTO_Out>>(pedidos);
        }

        public async Task<IEnumerable<PedidoDTO_Out>> ListarNaoEmitidosAsync()
        {
            var pedidos = await _pedidoRepository.ListarNaoEmitidosAsync(["PedidoProdutos", "Revenda"]);
            return _mapper.Map<IEnumerable<PedidoDTO_Out>>(pedidos);
        }

        public async Task<PedidoDTO_Out> ObterPorIdAsync(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(id, ["PedidoProdutos"]);
            return _mapper.Map<PedidoDTO_Out>(pedido);
        }

        public async Task<PedidoDTO_Out> CriarAsync(PedidoDTO_In dto)
        {
            var pedido = _mapper.Map<Pedido>(dto);
            pedido.Identificador = $"P-{ToBase36(DateTime.UtcNow.Ticks)}";

            await _pedidoRepository.AdicionarAsync(pedido);
            return _mapper.Map<PedidoDTO_Out>(pedido);
        }

        public string GerarCodigoPedido(long idSequencial)
        {
            return idSequencial.ToString("X").Substring(0, 8).ToUpper();
        }
        public string ToBase36(long value)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var result = "";
            while (value > 0)
            {
                result = chars[(int)(value % 36)] + result;
                value /= 36;
            }
            return result.PadLeft(8, '0');
        }

        public async Task<PedidoDTO_Out?> AtualizarAsync(Guid id, PedidoDTO_In dto)
        {
            var pedido = _mapper.Map<Pedido>(dto);
            pedido.Id = id;

            await _pedidoRepository.AtualizarAsync(pedido);
            return _mapper.Map<PedidoDTO_Out>(pedido);
        }

        public async Task<bool> RemoverAsync(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(id);

            if (pedido != null)
                await _pedidoRepository.RemoverAsync(pedido);

            return true;
        }

    }
}
