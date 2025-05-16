using AutoMapper;
using PedidoBebidas.Dominio.Entidades;
using PedidoBebidas.Infraestrutura.Interfaces;
using PedidoBebidas.Infraestrutura.Persistencia;

namespace PedidoBebidas.Infraestrutura.Repositorios
{
    public class RevendaRepository(AppDbContext _context, IMapper _mapper) : BaseRepository<Revenda>(_context), IRevendaRepository
    {
        public override async Task AtualizarAsync(Revenda revenda)
        {
            var revendaBase = await ObterPorIdAsync(revenda.Id, ["Telefones", "Contatos", "EnderecosEntrega"]) ?? throw new Exception("Revenda não encontrada");

            _mapper.Map(revenda, revendaBase);

            #region Telefones

            foreach (var telefone in revenda.Telefones)
            {
                if (telefone.Id != Guid.Empty)
                {
                    var telefoneExistente = revendaBase.Telefones.FirstOrDefault(c => c.Id == telefone.Id);
                    if (telefoneExistente != null)
                        _mapper.Map(telefone, telefoneExistente);
                }
            }

            var idsTelefonesRecebidos = revenda.Telefones
                .Where(c => c.Id != Guid.Empty)
                .Select(c => c.Id)
                .ToHashSet();

            var telefonesParaRemover = revendaBase.Telefones
                .Where(c => c.Id != Guid.Empty && !idsTelefonesRecebidos.Contains(c.Id))
                .ToList();

            foreach (var telefone in telefonesParaRemover)
                _context.Telefones.Remove(telefone);

            #endregion

            #region Contatos

            foreach (var contato in revenda.Contatos)
            {
                if (contato.Id != Guid.Empty)
                {
                    var contatoExistente = revendaBase.Contatos.FirstOrDefault(c => c.Id == contato.Id);
                    if (contatoExistente != null)
                        _mapper.Map(contato, contatoExistente);
                }
            }

            var idsContatosRecebidos = revenda.Contatos
                .Where(c => c.Id != Guid.Empty)
                .Select(c => c.Id)
                .ToHashSet();

            var contatosParaRemover = revendaBase.Contatos
                .Where(c => c.Id != Guid.Empty && !idsContatosRecebidos.Contains(c.Id))
                .ToList();

            foreach (var contato in contatosParaRemover)
                _context.Contatos.Remove(contato);

            #endregion

            #region Endereços Entrega

            foreach (var enderecoEntrega in revenda.EnderecosEntrega)
            {
                if (enderecoEntrega.Id != Guid.Empty)
                {
                    var enderecoEntregaExistente = revendaBase.EnderecosEntrega.FirstOrDefault(c => c.Id == enderecoEntrega.Id);
                    if (enderecoEntregaExistente != null)
                        _mapper.Map(enderecoEntrega, enderecoEntregaExistente);
                }
            }

            var idsEnderecosEntregaRecebidos = revenda.EnderecosEntrega
                .Where(c => c.Id != Guid.Empty)
                .Select(c => c.Id)
                .ToHashSet();

            var enderecosEntregaParaRemover = revendaBase.EnderecosEntrega
                .Where(c => c.Id != Guid.Empty && !idsEnderecosEntregaRecebidos.Contains(c.Id))
                .ToList();

            foreach (var enderecoEntrega in enderecosEntregaParaRemover)
                _context.EnderecosEntrega.Remove(enderecoEntrega);

            #endregion

            await _context.SaveChangesAsync();
        }
    }
}