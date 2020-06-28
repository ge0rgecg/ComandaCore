using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Repositorio.Config;

namespace Repositorio.Contexto
{
    public class ContextoDb : DbContext
    {
        public ContextoDb(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Fechamento> Fechamento { get; set; }

        public DbSet<ControleComanda> ControleComanda { get; set; }

        public DbSet<Combo> Combo { get; set; }

        public DbSet<ComboItem> ComboItems { get; set; }

        public DbSet<ComboDesconto> ComboDescontos { get; set; }

        public DbSet<LimiteProduto> LimiteProduto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }

            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new FechamentoConfig());
            modelBuilder.ApplyConfiguration(new ControleComandaConfig());
            modelBuilder.ApplyConfiguration(new ComboConfig());
            modelBuilder.ApplyConfiguration(new ComboDescontoConfig());
            modelBuilder.ApplyConfiguration(new ComboItemConfig());
            modelBuilder.ApplyConfiguration(new LimiteProdutoConfig());

        }
    }
}
