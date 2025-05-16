using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoBebidas.Dominio.Entidades
{
    public class EnderecoEntrega : BaseEntidade
    {
        [Required]
        [StringLength(200)]
        public string Logradouro { get; set; }
        
        [StringLength(50)]
        public string Numero { get; set; }
        
        [StringLength(50)]
        public string Complemento { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Bairro { get; set; }
        
        [Required]
        [StringLength(9)]
        public string Cep { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Cidade { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Estado { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Pais { get; set; }

        [ForeignKey("Revenda")]
        public Guid RevendaId { get; set; }
        public Revenda Revenda { get; set; }
    }
}
