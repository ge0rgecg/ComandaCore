using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Fechamento> Fechamento { get; set; }

        public DbSet<ControleComanda> ControleComanda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(h => h.Id);

                entity.Property(p => p.Id).HasColumnName("Id_Produto");
            });
            //modelBuilder
            modelBuilder.Entity<ControleComanda>(entity =>
            {
                entity.HasKey(h => h.Id);

                entity.Property(p => p.Id).HasColumnName("Id_ControleComando");

                entity.HasOne(o => o.Produto)
                    .WithMany(m => m.ControleComandas)
                    .HasConstraintName("FK_Controle_Comanda_Produto");

                entity.HasOne(o => o.Fechamento)
                    .WithMany(m => m.ControleComandas)
                    .HasConstraintName("FK_Controle_Comanda_Fechamento");
            });
        }
    }
}
