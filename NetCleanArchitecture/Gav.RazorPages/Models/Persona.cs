using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gav.RazorPages.Models
{
    public class Persona
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(20)]
        public string Nombre { get; set; }
        [Range(0,120)]
        public int? Edad { get; set; }
        public Pais Pais { get; set; }
        public string Pregunta { get; set; }
        public string Descripcion { get; set; }
    }

    public enum Pais
    {
        [Display(Name="--Escoger--")]
        Desconocido = 0,
        [Display(Name = "República Dominicana")]
        RepDominicana = 1,
        Mexico = 2,
        [Display(Name = "Costa Rica")]
        CostaRica = 3
    }
}
