using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gav.DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gav.DependencyInjection.Pages
{
    public class IndexModel : PageModel
    {
        //readonly IEmailService _emailService;

        public string Mensaje { get; set; }

        public IndexModel()
        {
            //_emailService = emailService;
        }

        public void OnGet([FromServices] IEmailService email)
        {
           // Mensaje = _emailService.EnviarCorreo();
            Mensaje = email.EnviarCorreo();
        }
    }
}
