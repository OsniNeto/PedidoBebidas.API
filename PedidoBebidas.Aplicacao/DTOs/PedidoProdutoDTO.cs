using System.ComponentModel.DataAnnotations;

namespace PedidoBebidas.Aplicacao.DTOs
{
    public class PedidoProdutoDTO_In
    {
        [Required(ErrorMessage = "Produto é obrigatório.")]
        public string Produto { get; set; }
        public int Quantidade { get; set; }
    }

    public class PedidoProdutoDTO_Out : BaseDTO
    {
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public Guid PedidoId { get; set; }
    }
}