using System.ComponentModel.DataAnnotations;

namespace PedidoBebidas.Dominio.Entidades
{
    public class Revenda : BaseEntidade
    {
        [Required]
        public string Cnpj { get; set; }

        [Required]
        [StringLength(200)]
        public string RazaoSocial { get; set; }

        [Required]
        [StringLength(200)]
        public string NomeFantasia { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; }

        public List<Telefone> Telefones { get; set; } = [];

        public List<Contato> Contatos { get; set; } = [];

        public List<EnderecoEntrega> EnderecosEntrega { get; set; } = [];
    }
}
