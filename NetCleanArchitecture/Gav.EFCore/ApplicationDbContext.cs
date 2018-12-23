using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Gav.EFCore
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<EstudianteCurso> EstudiantesCursos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFCore;Trusted_Connection=True;MultipleActiveResultSets=true",
                options =>
                {
                    
                })
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new LoggerFactory().AddConsole((category,level) => level == LogLevel.Information && category == DbLoggerCategory.Database.Command.Name,true));


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstudianteCurso>().HasKey(x => new{x.CursoId, x.EstudianteId});

            modelBuilder.Entity<EstudianteCurso>().HasQueryFilter(x => x.Activo == true);
        }

        public override int SaveChanges()
        {
            // Borrado suave
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted && e.Metadata.GetProperties().Any(x=> x.Name == "EstaBorrado")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["EstaBorrado"] = true;
            }

            return base.SaveChanges();
        }


        [DbFunction(Schema = "dbo")]
        public static int Cantidad_De_Cursos_Activos(int estudianteId)
        {
            throw new Exception();
        }
    }
}
