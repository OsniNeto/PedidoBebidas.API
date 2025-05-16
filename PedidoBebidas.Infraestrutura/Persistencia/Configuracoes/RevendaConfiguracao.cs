using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidoBebidas.Dominio.Entidades;

namespace PedidoBebidas.Infraestrutura.Persistencia.Configuracoes
{
    public class EmpresaConfiguracao : IEntityTypeConfiguration<Revenda>
    {
        public void Configure(EntityTypeBuilder<Revenda> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Cnpj).IsRequired();
            builder.Property(c => c.RazaoSocial).IsRequired();
            builder.Property(c => c.NomeFantasia).IsRequired();
            builder.Property(c => c.Email).IsRequired();
        }
    }
}