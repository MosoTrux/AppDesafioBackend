using System;
using AppDesafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AppDesafio.Infrastructure.Data.SqlServer
{
    public partial class DesafioDBContext : DbContext
    {
        public DesafioDBContext()
        {
        }

        public DesafioDBContext(DbContextOptions<DesafioDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TipoCambio> TipoCambios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TipoCambio>(entity =>
            {
                entity.ToTable("TipoCambio");

                entity.HasIndex(e => e.Id, "IX_TipoCambio")
                    .IsUnique();

                entity.Property(e => e.CodigoIso)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CodigoISO")
                    .IsFixedLength(true);

                entity.Property(e => e.Divisa)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 6)");
            });

        }

    }
}
