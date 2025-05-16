using System.ComponentModel.DataAnnotations;

namespace PedidoBebidas.Aplicacao.DTOs
{
    public class EmissaoPedidoDTO_In
    {
        [Required(ErrorMessage = "Pedido é obrigatório.")]
        public Guid PedidoId { get; set; }
    }

    public class EmissaoPedidoDTO_Out : BaseDTO
    {
        public Guid PedidoId { get; set; }
        public PedidoDTO_Out Pedido { get; set; }
    }
}