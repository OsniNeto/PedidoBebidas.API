using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidoBebidas.Dominio.Entidades;
using System.Reflection.Emit;

namespace PedidoBebidas.Infraestrutura.Persistencia.Configuracoes
{
    public class EmissaoConfiguracao : IEntityTypeConfiguration<Emissao>
    {
        public void Configure(EntityTypeBuilder<Emissao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();
        }
    }
}