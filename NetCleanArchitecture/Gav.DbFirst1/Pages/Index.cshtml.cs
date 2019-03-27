using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gav.DbFirst1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gav.DbFirst1.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            using (var context = new EFCoreContext())
            {
                var estudiantes = context.Estudiantes.ToList();
            }
        }
    }
}
