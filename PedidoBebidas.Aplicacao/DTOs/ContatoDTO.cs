using System.ComponentModel.DataAnnotations;

namespace PedidoBebidas.Aplicacao.DTOs
{
    public class ContatoDTO_In
    {
        [Required(ErrorMessage = "Nome do contato é obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; }

        public bool Principal { get; set; }
    }

    public class ContatoDTO_Out : BaseDTO
    {
        public string Nome { get; set; }
        public bool Principal { get; set; }
    }
}