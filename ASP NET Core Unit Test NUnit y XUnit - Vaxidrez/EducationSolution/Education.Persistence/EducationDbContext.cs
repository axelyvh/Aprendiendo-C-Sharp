using Edutacion.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Education.Persistence
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext()
        {
        }

        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            if (!options.IsConfigured) {
                options.UseSqlServer("Server=AXELYVH\\SQLEXPRESS;database=Education;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Curso>().Property(x => x.Precio).HasPrecision(14, 2);

            modelBuilder.Entity<Curso>().HasData(
                
                new Curso { 
                    CursoId = Guid.NewGuid(), 
                    Descripcion = "Curso de c# basico", 
                    Titulo = "C# desde cero hasta avanzado",
                    FechaCreacion = DateTime.Now, 
                    FechaPublicacion = DateTime.Now.AddYears(2), 
                    Precio = 56
                },

                new Curso { 
                    CursoId = Guid.NewGuid(), 
                    Descripcion = "Curso de java", 
                    Titulo = "Master en Java spring desde las raices",
                    FechaCreacion = DateTime.Now, 
                    FechaPublicacion = 
                    DateTime.Now.AddYears(2), 
                    Precio = 25
                },

                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion = "Curso de unit test para net core",
                    Titulo = "Master en UNIT Test con CQRS",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 1000
                }

                );
        }

    }
}
