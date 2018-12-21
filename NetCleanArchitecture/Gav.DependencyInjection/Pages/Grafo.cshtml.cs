using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gav.DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gav.DependencyInjection.Pages
{
    public class GrafoModel : PageModel
    {
        public string MensajeDelServicio { get; private set; }

        public IServicioA ServicioA { get; }

        public GrafoModel(IServicioA servicioA)
        {
            ServicioA = servicioA;
            MensajeDelServicio = ServicioA.ObtenerMensaje();
        }

        
       
        public void OnGet()
        {
        }
    }
}