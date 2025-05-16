using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidoBebidas.Dominio.Entidades;

namespace PedidoBebidas.Infraestrutura.Persistencia.Configuracoes
{
    public class PedidoProdutoConfiguracao : IEntityTypeConfiguration<PedidoProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoProduto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Produto).IsRequired();
        }
    }
}