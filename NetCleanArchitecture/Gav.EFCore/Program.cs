using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Gav.EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var context = new ApplicationDbContext())
            {
                var customer = new Customer()
                {
                    CustomerId = "CDR00004",
                    Name = "Customer 4",
                    HasAccess = true
                };

                context.Customers.Add(customer);
                context.SaveChanges();
            }
            

            Console.WriteLine("Listo");
            Console.ReadLine();
        }



        static void EjemploInsertarEstudiante(string persona)
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiante = new Estudiante();
                estudiante.Nombre = persona;

                context.Estudiantes.Add(estudiante);
                context.SaveChanges();

            }
        }

        static void EjemploActualizarEstudianteModeloConectado()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiantes = context.Estudiantes.Where(x => x.Nombre == "Ivan").ToList();

                estudiantes[0].Nombre += "Apellido";
                context.SaveChanges();
            }
        }

        static void EjemploActualizarEstudianteModeloDesconectado(Estudiante estudiante)
        {
            
            using (var context = new ApplicationDbContext())
            {
                context.Entry(estudiante).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        static void AgregarModeloUnoAUnoConectado()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiante = new Estudiante();
                estudiante.Nombre = "Claudio";
                estudiante.Edad = 29;

                var direccion = new Direccion();
                direccion.Calle = "Ejemplo";
                estudiante.Direccion = direccion;

                context.Add(estudiante);
                context.SaveChanges();
            }
        }

        static void AgregarModeloUnoAUnodesconectado(Direccion direcc)
        {
            var estudianteClaudio = new Estudiante();
            estudianteClaudio.Id = 3;

            var direccion2 = new Direccion();
            direccion2.Id = 2;
            direccion2.Calle = "Ejemplo 3";
            direccion2.EstudianteId = estudianteClaudio.Id;

            // Modelo desconectado (el campo direccion.estudianteId debe estar lleno)
            using (var context = new ApplicationDbContext())
            {
                context.Entry(direcc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }

        }

        static void TraerDataRelacionadaUnoAUno()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiantes = context.Estudiantes.Include(x => x.Direccion).ToList();
            }
        }

        static void TraerDataRelacionadaUnoAMuchos()
        {
            using (var context = new ApplicationDbContext())
            {
                // error
                //var institucion = context.Instituciones.Where(x => x.Id == 1).Include(x => x.Estudiantes.where(e => e.Edad >18)).ToList();

                //var persona = context.Estudiantes.Select(x => new {prop = x.Id, prop1 = x.Nombre }).FirstOrDefault();

                var institucionesEstudiantes = context.Instituciones.Where(x => x.Id == 1)
                    .Select(x => new { Institucion = x, Estudiantes = x.Estudiantes.Where(e => e.Edad > 18).ToList() }).ToList();
            }
        }

        static void AgregarModeloMuchosAMuchosModeloDesconectado()
        {
            //using (var context = new ApplicationDbContext())
            //{
            //    var estudiante = context.Estudiantes.FirstOrDefault();
            //    var curso = context.Cursos.FirstOrDefault();

            //    var estudianteCurso = new EstudianteCurso();
            //    estudianteCurso.CursoId = curso.Id;
            //    estudianteCurso.EstudianteId = estudiante.Id;
            //    estudianteCurso.Activo = true;
            //    context.Add(estudianteCurso);
            //    context.SaveChanges();

            //}

            using (var context = new ApplicationDbContext())
            {
                var curso = context.Cursos.Where(x => x.Id == 1)
                    .Include(x => x.EstudiantesCursos)
                    .ThenInclude(y => y.Estudiante).FirstOrDefault();
            }
        }

        static void FilterQuery()
        {
            // Filter query configurado en fluent api

            using (var context = new ApplicationDbContext())
            {
                var estudiantesCursos = context.EstudiantesCursos.ToList();
            }
        }

        static void StringInterpolationSqlInjection()
        {
            using (var context = new ApplicationDbContext())
            {
                var nombre = "'Ivan'";
                var estudiante = context.Estudiantes.FromSql($"select * from Estudiantes where Nombre = {nombre}").ToList();
            }
        }

        static void BorradoSuave()
        {

            // Primero implementarlo en override del metodo savechanges en DbContext

            using (var context = new ApplicationDbContext())
            {
                var estudiante = context.Estudiantes.FirstOrDefault();
                context.Remove(estudiante);
                context.SaveChanges();
            }
        }

        static void concurrencyCheck()
        {
            using (var context = new ApplicationDbContext())
            {
                var est = context.Estudiantes.FirstOrDefault();

                est.Nombre += " 2";
                est.Edad++;

                context.SaveChanges();
            }
        }

        static void FuncionEscalarFromSqlServer()
        {
            // Implementar funcion escalar en DbContext

            using (var context = new ApplicationDbContext())
            {
                var estudiantes = context.Estudiantes
                    .Where(x => ApplicationDbContext.Cantidad_De_Cursos_Activos(x.Id) > 0).ToList();
            }
        }

        static void TableSpliting()
        {
            using (var context = new ApplicationDbContext())
            {
                //var estudiante = new Estudiante();
                //estudiante.Nombre = "Carlos";
                //estudiante.Edad = 45;
                //estudiante.EstaBorrado = false;
                //estudiante.InstitucionId = 1;

                //var detalle = new EstudianteDetalle();
                //detalle.Becado = false;
                //detalle.Carrera = "Lic. en Matematicas";
                //detalle.CategoriaDePago = 1;

                //estudiante.Detalles = detalle;

                //context.Add(estudiante);
                //context.SaveChanges();

                context.Estudiantes.Include(x => x.Detalles).ToList();

                // si no quieres usar table splitting utiliza select en el query


            }
        }

        static void MapeoFlexible()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudiante = new Estudiante()
                {
                    Nombre = "Carlos",
                    Edad = 56,
                    EstaBorrado = false,
                    InstitucionId = 1,
                    Detalles = new EstudianteDetalle() { CategoriaDePago = 1, Becado = false },
                    Apellido = "Carvajal"
                };

                context.Add(estudiante);
                context.SaveChanges();
            }
        }
    }

    class Institucion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Estudiante> Estudiantes { get; set; }

    }

    class Estudiante
    {
        public int Id { get; set; }
        [ConcurrencyCheck]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int InstitucionId { get; set; }
        public bool EstaBorrado { get; set; }

        private string _apellido;

        public string Apellido { get { return _apellido; } set{ _apellido = value.ToUpper(); } }
        public Direccion Direccion { get; set; }
        public List<EstudianteCurso> EstudiantesCursos { get; set; }
        public EstudianteDetalle Detalles { get; set; }
    }

    class EstudianteDetalle
    {
        public int Id { get; set; }
        public bool Becado { get; set; }
        public string Carrera { get; set; }
        public int CategoriaDePago { get; set; }
        public Estudiante Estudiante { get; set; }
    }

    class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int EstudianteId { get; set; }
    }

    class Curso
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        public List<EstudianteCurso> EstudiantesCursos { get; set; }
    }

    class EstudianteCurso
    {
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }
        public bool Activo { get; set; }
        public Estudiante Estudiante { get; set; }
        public Curso Curso { get; set; }
    }

    class Customer
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public bool HasAccess { get; set; }
    }
}
