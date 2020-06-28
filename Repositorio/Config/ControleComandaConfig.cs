using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config
{
    public class ControleComandaConfig : IEntityTypeConfiguration<ControleComanda>
    {
        public void Configure(EntityTypeBuilder<ControleComanda> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(p => p.Id).HasColumnName("Id_ControleComanda");
            builder.Property(p => p.Fechamento_Id).HasColumnName("Fechamento_Id");
            builder.Property(p => p.Produto_Id).HasColumnName("Produto_Id");

            builder.HasOne(o => o.Produto)
                    .WithMany(m => m.ControleComandas)
                    .HasForeignKey(f => f.Produto_Id);

            builder.HasOne(o => o.Fechamento)
                    .WithMany(m => m.ControleComandas)
                    .HasForeignKey(f => f.Fechamento_Id);
            
        }
    }
}
