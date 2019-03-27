using System;
using System.Collections.Generic;

namespace Gav.DbFirst1.Models
{
    public partial class EstudiantesCursos
    {
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }
        public bool Activo { get; set; }

        public Cursos Curso { get; set; }
        public Estudiantes Estudiante { get; set; }
    }
}
