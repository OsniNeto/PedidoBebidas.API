using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoBebidas.Dominio.Entidades
{
    public class Pedido : BaseEntidade
    {
        [Required]
        [StringLength(50)]
        public string Cliente { get; set; }

        [Required]
        [StringLength(50)]
        public string Identificador { get; set; }

        [ForeignKey("Revenda")]
        public Guid RevendaId { get; set; }
        public Revenda Revenda { get; set; }

        public List<PedidoProduto> PedidoProdutos { get; set; } = [];
        public List<EmissaoPedido> Emissoes { get; set; } = [];
    }
}