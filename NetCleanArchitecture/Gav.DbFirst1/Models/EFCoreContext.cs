using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gav.DbFirst1.Models
{
    public partial class EFCoreContext : DbContext
    {
        public EFCoreContext()
        {
        }

        public EFCoreContext(DbContextOptions<EFCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<EstudiantesCursos> EstudiantesCursos { get; set; }
        public virtual DbSet<Instituciones> Instituciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFCore;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Direcciones>(entity =>
            {
                entity.HasIndex(e => e.EstudianteId)
                    .IsUnique();

                entity.HasOne(d => d.Estudiante)
                    .WithOne(p => p.Direcciones)
                    .HasForeignKey<Direcciones>(d => d.EstudianteId);
            });

            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.HasIndex(e => e.InstitucionId);

                entity.HasOne(d => d.Institucion)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.InstitucionId);
            });

            modelBuilder.Entity<EstudiantesCursos>(entity =>
            {
                entity.HasKey(e => new { e.CursoId, e.EstudianteId });

                entity.HasIndex(e => e.EstudianteId);

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.EstudiantesCursos)
                    .HasForeignKey(d => d.CursoId);

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.EstudiantesCursos)
                    .HasForeignKey(d => d.EstudianteId);
            });
        }
    }
}
