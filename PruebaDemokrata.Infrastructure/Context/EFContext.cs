using Microsoft.EntityFrameworkCore;
using PruebaDemokrata.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDemokrata.Infrastructure.Context
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            getUsuario(modelBuilder);
        }

        private static void getUsuario(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("usuarios");

                entity.HasKey(e => e.Id);
              
                entity.Property(e => e.Id)
                     .HasColumnName("id")
                     .ValueGeneratedOnAdd();

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.PrimerApellido).HasMaxLength(50);

                entity.Property(e => e.PrimerNombre).HasMaxLength(50);

                entity.Property(e => e.SegundoApellido).HasMaxLength(50);

                entity.Property(e => e.SegundoNombre).HasMaxLength(50);

                entity.Property(e => e.Sueldo).HasColumnType("decimal(10, 2)");
            });
        }


    }
}
