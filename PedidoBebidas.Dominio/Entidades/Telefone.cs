using PedidoBebidas.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PedidoBebidas.Dominio.Entidades
{
    public class Telefone : BaseEntidade
    {
        [Required]
        [Phone]
        [StringLength(50)]
        public string Numero { get; set; }

        [ForeignKey("Revenda")]
        public Guid RevendaId { get; set; }
        public Revenda Revenda { get; set; }
    }
}
