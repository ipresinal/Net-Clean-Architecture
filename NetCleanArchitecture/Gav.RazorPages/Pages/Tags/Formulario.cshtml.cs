using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gav.RazorPages.Models;

namespace Gav.RazorPages.Pages.Tags
{
    public class FormularioModel : PageModel
    {
        [BindProperty]
        public Models.Persona Persona { get; set; }

        public List<SelectListItem> PreguntasSeguridad
        {
            get
            {
                string escogido = Persona?.Pregunta;
                var preguntas = ObtenerPreguntasDeSeguridad();
                var opciones = new List<SelectListItem>();
                foreach (var pregunta in preguntas)
                {
                    opciones.Add(new SelectListItem()
                    {
                        Text = pregunta,
                        Value = pregunta,
                        Selected = pregunta == escogido
                    });
                }
                return opciones;
            }
            
        }

        public void OnGet()
        {

        }

        private List<string> ObtenerPreguntasDeSeguridad()
        {
            return new List<string>()
            {
              "Cuál es la nacionalidad d su perro?",
                "Pepsi o Coca cola?",
                "Nombre de una persona que usted conoce"
            };
        }

        public void OnPost()
        {

        }

        [ValidateAntiForgeryToken]
        public void OnPostConToken()
        {

        }
    }
}