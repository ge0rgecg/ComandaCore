using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config
{
    public class ComboItemConfig : IEntityTypeConfiguration<ComboItem>
    {
        public void Configure(EntityTypeBuilder<ComboItem> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(p => p.Id).HasColumnName("Id_ComboItem");
            builder.Property(p => p.Combo_Id).HasColumnName("Combo_Id");
            builder.Property(p => p.Produto_Id).HasColumnName("Produto_Id");
            builder.Property(p => p.Quantidade).HasColumnName("Quantidade");

            builder.HasOne(o => o.Combo)
                    .WithMany(m => m.ComboItem)
                    .HasForeignKey(f => f.Combo_Id);
            
        }
    }
}
