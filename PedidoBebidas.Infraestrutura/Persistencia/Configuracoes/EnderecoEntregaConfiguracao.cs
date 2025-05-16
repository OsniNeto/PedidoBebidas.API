using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidoBebidas.Dominio.Entidades;

namespace PedidoBebidas.Infraestrutura.Persistencia.Configuracoes
{
    public class EnderecoEntregaConfiguracao : IEntityTypeConfiguration<EnderecoEntrega>
    {
        public void Configure(EntityTypeBuilder<EnderecoEntrega> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Logradouro).IsRequired();
            builder.Property(e => e.Bairro).IsRequired();
            builder.Property(e => e.Cep).IsRequired();
            builder.Property(e => e.Cidade).IsRequired();
            builder.Property(e => e.Estado).IsRequired();
            builder.Property(e => e.Pais).IsRequired();
        }
    }
}