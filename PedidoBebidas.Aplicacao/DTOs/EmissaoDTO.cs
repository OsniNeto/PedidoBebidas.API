using System.ComponentModel.DataAnnotations;

namespace PedidoBebidas.Aplicacao.DTOs
{
    public class EmissaoDTO_In : IValidatableObject
    {
        public List<Guid> Pedidos { get; set; } = [];

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Pedidos == null || Pedidos.Count == 0)
                yield return new ValidationResult("Pelo menos um pedido deve ser informado.", ["Emissao"]);
        }
    }

    public class EmissaoDTO_Out : BaseDTO
    {
        public bool Sucesso { get; set; }

        public List<EmissaoPedidoDTO_Out> Pedidos { get; set; } = [];
        public List<EmissaoTentativaEnvioDTO_Out> TentativasEnvio { get; set; } = [];
    }
}