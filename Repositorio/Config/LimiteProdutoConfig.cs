using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config
{
    public class LimiteProdutoConfig : IEntityTypeConfiguration<LimiteProduto>
    {
        public void Configure(EntityTypeBuilder<LimiteProduto> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(p => p.Id).HasColumnName("Id_LimiteProduto");
            builder.Property(p => p.QuantidadeLimite).HasColumnName("QuantidadeLimite");
        }
    }
}
