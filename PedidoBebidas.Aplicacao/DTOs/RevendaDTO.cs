using System.ComponentModel.DataAnnotations;

namespace PedidoBebidas.Aplicacao.DTOs
{
    public class RevendaDTO_In : IValidatableObject
    {
        [Required(ErrorMessage = "CNPJ é obrigatório.")]
        [CnpjValidation(ErrorMessage = "CNPJ inválido.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Razão Social é obrigatória.")]
        [StringLength(150, ErrorMessage = "Razão Social deve ter até 150 caracteres.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Nome Fantasia é obrigatório.")]
        [StringLength(150, ErrorMessage = "Nome Fantasia deve ter até 150 caracteres.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        public List<TelefoneDTO_In> Telefones { get; set; } = [];
        public List<ContatoDTO_In> Contatos { get; set; } = [];
        public List<EnderecoEntregaDTO_In> EnderecosEntrega { get; set; } = [];

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Contatos == null || Contatos.Count == 0)
                yield return new ValidationResult("Pelo menos um contato deve ser informado.", [nameof(Contatos)]);

            if (EnderecosEntrega == null || EnderecosEntrega.Count == 0)
                yield return new ValidationResult("Pelo menos um endereço de entrega deve ser informado.", [nameof(EnderecosEntrega)]);
        }
    }

    public class RevendaDTO_Out : BaseDTO
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }

        public List<TelefoneDTO_Out> Telefones { get; set; } = [];
        public List<ContatoDTO_Out> Contatos { get; set; } = [];
        public List<EnderecoEntregaDTO_Out> EnderecosEntrega { get; set; } = [];
    }
}