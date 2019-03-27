using System;
using System.Collections.Generic;

namespace Gav.DbFirst1.Models
{
    public partial class Instituciones
    {
        public Instituciones()
        {
            Estudiantes = new HashSet<Estudiantes>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Estudiantes> Estudiantes { get; set; }
    }
}
