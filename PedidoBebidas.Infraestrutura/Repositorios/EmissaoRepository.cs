using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PedidoBebidas.Dominio.Entidades;
using PedidoBebidas.Infraestrutura.Interfaces;
using PedidoBebidas.Infraestrutura.Persistencia;

namespace PedidoBebidas.Infraestrutura.Repositorios
{
    public class EmissaoRepository(AppDbContext _context) : BaseRepository<Emissao>(_context), IEmissaoRepository
    {
        public override async Task<Emissao?> ObterPorIdAsync(Guid id, List<string>? includes = null)
        {
            // Não performático, mas para fins de exibição estou usando
            var query = _context.Emissoes
                .AsQueryable()
                .Include(x => x.Pedidos).ThenInclude(x => x.Pedido).ThenInclude(x => x.PedidoProdutos)
                .Include(x => x.Pedidos).ThenInclude(x => x.Pedido).ThenInclude(x => x.Revenda);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Emissao> AdicionarAsync(List<Guid> idsPedidos)
        {
            var emissao = new Emissao { Sucesso = false };

            foreach (var id in idsPedidos)
                emissao.Pedidos.Add(new EmissaoPedido { PedidoId = id });

            _context.Emissoes.Add(emissao);

            await _context.SaveChangesAsync();

            return emissao;
        }

        public async Task<Emissao> AtualizarAsync(Guid id, List<Guid> idsPedidos)
        {
            var emissao = await ObterPorIdAsync(id, ["Pedidos"]) ?? throw new Exception("Emissão não encontrada");

            #region Pedidos

            var pedidosParaRemover = emissao.Pedidos
                .Where(c => !idsPedidos.Contains(c.PedidoId))
                .ToList();

            foreach (var pedidoProduto in pedidosParaRemover)
                _context.EmissaoPedido.Remove(pedidoProduto);

            var pedidosParaAdicionar = idsPedidos.Except(emissao.Pedidos.Select(x => x.PedidoId)).ToList();

            foreach (var idPedido in pedidosParaAdicionar)
                emissao.Pedidos.Add(new EmissaoPedido { PedidoId = idPedido });

            #endregion

            await _context.SaveChangesAsync();
            return emissao;
        }

        public async Task SetarEnviadoAsync(Guid id, bool sucesso)
        {
            var emissao = await ObterPorIdAsync(id) ?? throw new Exception("Emissão não encontrada");

            emissao.Sucesso = sucesso;

            await _context.SaveChangesAsync();
        }
    }
}