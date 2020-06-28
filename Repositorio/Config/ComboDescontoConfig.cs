using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config
{
    public class ComboDescontoConfig : IEntityTypeConfiguration<ComboDesconto>
    {
        public void Configure(EntityTypeBuilder<ComboDesconto> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(p => p.Id).HasColumnName("Id_ComboDesconto");
            builder.Property(p => p.Combo_Id).HasColumnName("Combo_Id");
            builder.Property(p => p.Produto_Id).HasColumnName("Produto_Id");
            builder.Property(p => p.Porcentagem).HasColumnName("Porcentagem");

            builder.HasOne(o => o.Combo)
                    .WithMany(m => m.ComboDesconto)
                    .HasForeignKey(f => f.Combo_Id);
            
        }
    }
}
