using System.ComponentModel.DataAnnotations;

namespace PedidoBebidas.Aplicacao.DTOs
{
    public class EnderecoEntregaDTO_In
    {
        [Required(ErrorMessage = "Rua é obrigatória.")]
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório.")]
        //[RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP inválido. Use o formato 00000-000.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatória.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Pais é obrigatório.")]
        public string Pais { get; set; }
    }

    public class EnderecoEntregaDTO_Out : BaseDTO
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
    }
}