using System;
using System.Collections.Generic;

namespace Gav.DbFirst1.Models
{
    public partial class Direcciones
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int EstudianteId { get; set; }

        public Estudiantes Estudiante { get; set; }
    }
}
