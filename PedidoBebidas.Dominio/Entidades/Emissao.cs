namespace PedidoBebidas.Dominio.Entidades
{
    public class Emissao : BaseEntidade
    {
        public bool Sucesso { get; set; }

        public List<EmissaoPedido> Pedidos { get; set; } = [];
        public List<EmissaoTentativaEnvio> TentativasEnvio { get; set; } = [];
    }
}