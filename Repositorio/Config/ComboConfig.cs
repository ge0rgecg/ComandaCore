using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config
{
    public class ComboConfig : IEntityTypeConfiguration<Combo>
    {
        public void Configure(EntityTypeBuilder<Combo> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(p => p.Id).HasColumnName("Id_Combo");
            
            builder.HasMany(o => o.ComboDesconto)
                    .WithOne(m => m.Combo)
                    .HasForeignKey(f => f.Combo_Id);

            builder.HasMany(o => o.ComboItem)
                    .WithOne(m => m.Combo)
                    .HasForeignKey(f => f.Combo_Id);
            
        }
    }
}
