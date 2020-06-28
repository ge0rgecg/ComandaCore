using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositorio.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }

            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new FechamentoConfig());
            modelBuilder.ApplyConfiguration(new ControleComandaConfig());

        }
    }
}
