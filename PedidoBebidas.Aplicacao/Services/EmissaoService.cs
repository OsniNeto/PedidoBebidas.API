using AutoMapper;
using PedidoBebidas.Aplicacao.DTOs;
using PedidoBebidas.Aplicacao.Interfaces;
using PedidoBebidas.Dominio.Entidades;
using PedidoBebidas.Infraestrutura.Interfaces;

namespace PedidoBebidas.Aplicacao.Services
{
    public class EmissaoService(IEmissaoRepository _emissaoRepository, IEmissaoTentativaEnvioRepository _emissaoTentativaEnvioRepository, IMapper _mapper) : IEmissaoService
    {
        private readonly Random _random = new();
        private static readonly List<string> MensagensDeErro = new()
        {
            "Erro ao conectar ao servidor remoto.",
            "Timeout ao aguardar resposta da API.",
            "Erro interno no servidor (HTTP 500).",
            "Acesso negado. Verifique suas credenciais.",
            "Serviço temporariamente indisponível.",
            "Falha na autenticação do token.",
            "O servidor retornou uma resposta inválida.",
            "Erro inesperado: referência nula na resposta.",
            "Limite de requisições excedido (rate limit).",
            "Falha de comunicação: conexão encerrada pelo host.",
            "Erro de serialização dos dados de resposta.",
            "Requisição malformada (HTTP 400).",
            "Parâmetros inválidos enviados na requisição.",
            "O recurso solicitado não foi encontrado (HTTP 404)."
        };

        public async Task<IEnumerable<EmissaoDTO_Out>> ListarTodasAsync()
        {
            var emissaos = await _emissaoRepository.ListarTodasAsync(["Pedidos", "TentativasEnvio"]);
            return _mapper.Map<IEnumerable<EmissaoDTO_Out>>(emissaos);
        }

        public async Task<EmissaoDTO_Out> ObterPorIdAsync(Guid id)
        {
            var emissao = await _emissaoRepository.ObterPorIdAsync(id, ["Pedidos", "TentativasEnvio"]);
            return _mapper.Map<EmissaoDTO_Out>(emissao);
        }

        public async Task<EmissaoDTO_Out> CriarAsync(EmissaoDTO_In dto)
        {
            var emissao = await _emissaoRepository.AdicionarAsync(dto.Pedidos);
            return _mapper.Map<EmissaoDTO_Out>(emissao);
        }

        public async Task<EmissaoDTO_Out?> AtualizarAsync(Guid id, EmissaoDTO_In dto)
        {
            var emissao = await _emissaoRepository.AtualizarAsync(id, dto.Pedidos);
            return _mapper.Map<EmissaoDTO_Out>(emissao);
        }

        public async Task<bool> RemoverAsync(Guid id)
        {
            var emissao = await _emissaoRepository.ObterPorIdAsync(id);

            if (emissao != null)
                await _emissaoRepository.RemoverAsync(emissao);

            return true;
        }

        public async Task<EmissaoTentativaEnvioDTO_Out> EnviarAsync(Guid id)
        {
            var sucesso = true;
            var mensagem = "Envio realizado com sucesso";

            var emissao = await _emissaoRepository.ObterPorIdAsync(id);

            if (emissao == null)
            {
                sucesso = false;
                mensagem = "Pedido não encontrado";
            }
            else
            {
                var totalQuantidade = emissao.Pedidos
                    .Select(p => p.Pedido.PedidoProdutos.Sum(pp => pp.Quantidade))
                    .Sum();

                if (totalQuantidade < 1000)
                {
                    sucesso = false;
                    mensagem = "Deve haver pelo menos 1000 unidade (somatório de todos os itens)";
                }
                else if (_random.Next(100) < 40) // Simulação de erro com 40% de chance de falha
                {
                    sucesso = false;
                    mensagem = MensagensDeErro[_random.Next(MensagensDeErro.Count)];
                }
            }

            var tentantiva = new EmissaoTentativaEnvio { EmissaoId = id, Sucesso = sucesso, Mensagem = mensagem };
            await _emissaoTentativaEnvioRepository.AdicionarAsync(tentantiva);

            if (sucesso)
                await _emissaoRepository.SetarEnviadoAsync(id, sucesso);

            return _mapper.Map<EmissaoTentativaEnvioDTO_Out>(tentantiva);
        }

        public async Task<EmissaoTentativaEnvioDTO_Out> ObterTentativasPorIdAsync(Guid id)
        {
            var emissao = await _emissaoTentativaEnvioRepository.ObterPorEmissaoIdAsync(id);
            return _mapper.Map<EmissaoTentativaEnvioDTO_Out>(emissao);
        }

    }
}
