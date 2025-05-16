using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PedidoBebidas.Dominio.Entidades;
using PedidoBebidas.Infraestrutura.Interfaces;
using PedidoBebidas.Infraestrutura.Persistencia;

namespace PedidoBebidas.Infraestrutura.Repositorios
{
    public class PedidoRepository(AppDbContext _context, IMapper _mapper) : BaseRepository<Pedido>(_context), IPedidoRepository
    {
        public async Task<IEnumerable<Pedido>> ListarNaoEmitidosAsync(List<string>? includes = null)
        {
            var query = _context.Pedidos
                .AsNoTracking()
                .Where(x => !x.Emissoes.Any());

            if (includes != null && includes.Count != 0)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }

        public override async Task AtualizarAsync(Pedido pedido)
        {
            var pedidoBase = await ObterPorIdAsync(pedido.Id, ["PedidoProdutos"]) ?? throw new Exception("Pedido não encontrado");

            _mapper.Map(pedido, pedidoBase);

            #region Produtos

            foreach (var pedidoProduto in pedido.PedidoProdutos)
            {
                if (pedidoProduto.Id != Guid.Empty)
                {
                    var pedidoProdutoExistente = pedidoBase.PedidoProdutos.FirstOrDefault(c => c.Id == pedidoProduto.Id);
                    if (pedidoProdutoExistente != null)
                        _mapper.Map(pedidoProduto, pedidoProdutoExistente);
                }
            }

            var idsPedidoProdutosRecebidos = pedido.PedidoProdutos
                .Where(c => c.Id != Guid.Empty)
                .Select(c => c.Id)
                .ToHashSet();

            var pedidoProdutosParaRemover = pedidoBase.PedidoProdutos
                .Where(c => c.Id != Guid.Empty && !idsPedidoProdutosRecebidos.Contains(c.Id))
                .ToList();

            foreach (var pedidoProduto in pedidoProdutosParaRemover)
                _context.PedidoProdutos.Remove(pedidoProduto);

            #endregion

            await _context.SaveChangesAsync();
        }
    }
}