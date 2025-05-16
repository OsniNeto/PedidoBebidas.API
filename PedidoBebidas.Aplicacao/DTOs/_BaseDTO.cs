using System.ComponentModel.DataAnnotations;

namespace PedidoBebidas.Aplicacao.DTOs
{
    public class BaseDTO
    {
        public Guid? Id { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
