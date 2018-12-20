using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gav.RazorPages.Models;

namespace Gav.RazorPages.Pages.Peliculas
{
    public class IndexModel : PageModel
    {
        private readonly Gav.RazorPages.Models.ApplicationDbContext _context;

        public IndexModel(Gav.RazorPages.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Pelicula> Pelicula { get;set; }

        public async Task OnGetAsync()
        {
            Pelicula = await _context.Peliculas.ToListAsync();
        }
    }
}
