using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoBebidas.Dominio.Entidades
{
    public class EmissaoPedido : BaseEntidade
    {
        [ForeignKey("Emissao")]
        public Guid EmissaoId { get; set; }
        public Emissao Emissao { get; set; }


        [ForeignKey("Pedido")]
        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}