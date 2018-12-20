using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGav.Models
{
    public class Provincia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }


        [ForeignKey("Pais")]
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
    }
}
