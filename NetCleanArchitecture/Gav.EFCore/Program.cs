using System;
using System.Linq;

namespace Gav.EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var context = new ApplicationDbContext()) ;

          
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
    }

    class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public Direccion Direccion { get; set; }
    }

    class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int EstudianteId { get; set; }
    }
}
