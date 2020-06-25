using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config
{
    public class FechamentoConfig : IEntityTypeConfiguration<Fechamento>
    {
        public void Configure(EntityTypeBuilder<Fechamento> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(p => p.Id).HasColumnName("Id_Fechamento");
        }
    }
}
