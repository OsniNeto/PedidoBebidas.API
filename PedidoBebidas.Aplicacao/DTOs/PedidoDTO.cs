using PedidoBebidas.Dominio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace PedidoBebidas.Aplicacao.DTOs
{
    public class PedidoDTO_In : IValidatableObject
    {
        [Required(ErrorMessage = "Cliente é obrigatório.")]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "Revenda é obrigatório.")]
        public Guid RevendaId { get; set; }

        public List<PedidoProdutoDTO_In> PedidoProdutos { get; set; } = [];

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (RevendaId == Guid.Empty)
                yield return new ValidationResult("Id inválido para a revenda.", ["Pedido"]);
            if (PedidoProdutos == null || PedidoProdutos.Count == 0)
                yield return new ValidationResult("Pelo menos um produto deve ser informado.", [nameof(PedidoProdutos)]);
        }
    }

    public class PedidoDTO_Out : BaseDTO
    {
        public string Cliente { get; set; }
        public string Identificador { get; set; }

        public int QuantidadeTotalItens
        {
            get
            {
                if (PedidoProdutos?.Any() == true)
                    return PedidoProdutos.Select(x => x.Quantidade).Sum();
                return 0;
            }
        }

        public Guid RevendaId { get; set; }
        public RevendaDTO_Out Revenda { get; set; }

        public List<PedidoProdutoDTO_Out> PedidoProdutos { get; set; } = [];
    }
}