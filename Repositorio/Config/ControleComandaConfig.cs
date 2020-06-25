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

            builder.Property(p => p.Id).HasColumnName("Id_ControleComando");

            builder.HasOne(o => o.Produto)
                    .WithMany(m => m.ControleComandas)
                    .HasConstraintName("FK_Controle_Comanda_Produto");

            builder.HasOne(o => o.Fechamento)
                    .WithMany(m => m.ControleComandas)
                    .HasConstraintName("FK_Controle_Comanda_Fechamento");
            
        }
    }
}
