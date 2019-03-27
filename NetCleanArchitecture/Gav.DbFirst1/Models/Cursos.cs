using System;
using System.Collections.Generic;

namespace Gav.DbFirst1.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            EstudiantesCursos = new HashSet<EstudiantesCursos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<EstudiantesCursos> EstudiantesCursos { get; set; }
    }
}
