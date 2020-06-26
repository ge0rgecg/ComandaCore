using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositorio.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Contexto
{
    public class ContextoDb : DbContext
    {
        public ContextoDb(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Fechamento> Fechamento { get; set; }

        public DbSet<ControleComanda> ControleComanda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Properties()
            //    .Where(p => p.Name == "Id_" + //p.ReflectedType.Name)
            //    .Configure(p => p.IsKey());

            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new FechamentoConfig());
            modelBuilder.ApplyConfiguration(new ControleComandaConfig());

        }
    }
}
