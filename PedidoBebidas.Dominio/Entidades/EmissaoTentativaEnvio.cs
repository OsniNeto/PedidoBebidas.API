using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoBebidas.Dominio.Entidades
{
    public class EmissaoTentativaEnvio : BaseEntidade
    {
        public bool Sucesso { get; set; }

        [Required]
        [StringLength(200)]
        public string Mensagem { get; set; }

        [ForeignKey("Emissao")]
        public Guid EmissaoId { get; set; }
        public Emissao Emissao { get; set; }
    }
}