using System.Collections.Generic;
using System.Linq;
using HolaMundo.Data;
using HolaMundo.Models;

namespace HolaMundo.Services
{
    public class PaisRepositorioEF : IRepositorioPais
    {
        readonly ApplicationDbContext DbContext;

        public PaisRepositorioEF(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Pais> ObtenerTodos()
        {
            return DbContext.Paises.ToList();
        }
    }
}
