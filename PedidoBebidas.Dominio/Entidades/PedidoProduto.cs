using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoBebidas.Dominio.Entidades
{
    public class PedidoProduto : BaseEntidade
    {
        [Required]
        [StringLength(50)]
        public string Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [ForeignKey("Pedido")]
        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}
