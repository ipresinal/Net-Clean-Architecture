using System;
using System.Collections.Generic;

namespace Gav.DbFirst1.Models
{
    public partial class Estudiantes
    {
        public Estudiantes()
        {
            EstudiantesCursos = new HashSet<EstudiantesCursos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int InstitucionId { get; set; }
        public bool EstaBorrado { get; set; }
        public bool Becado { get; set; }
        public string Carrera { get; set; }
        public int CategoriaDePago { get; set; }

        public Instituciones Institucion { get; set; }
        public Direcciones Direcciones { get; set; }
        public ICollection<EstudiantesCursos> EstudiantesCursos { get; set; }
    }
}
