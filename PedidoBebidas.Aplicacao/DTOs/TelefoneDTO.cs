using System.ComponentModel.DataAnnotations;

namespace PedidoBebidas.Aplicacao.DTOs
{
    public class TelefoneDTO_In
    {
        [Required(ErrorMessage = "Número de telefone é obrigatório.")]
        [Phone(ErrorMessage = "Telefone inválido.")]
        public string Numero { get; set; }
    }

    public class TelefoneDTO_Out : BaseDTO
    {
        public string Numero { get; set; }
    }
}