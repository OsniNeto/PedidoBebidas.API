using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoBebidas.Dominio.Entidades
{
    public class Contato : BaseEntidade
    {
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required]
        public bool Principal { get; set; }

        [ForeignKey("Revenda")]
        public Guid RevendaId { get; set; }
        public Revenda Revenda { get; set; }
    }
}