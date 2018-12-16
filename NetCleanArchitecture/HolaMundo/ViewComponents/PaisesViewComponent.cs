using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolaMundo.Services;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundo.ViewComponents
{
    public class PaisesViewComponent : ViewComponent
    {

        readonly IRepositorioPais _repositorioPais;

        public PaisesViewComponent(IRepositorioPais repositorioPais)
        {
            _repositorioPais = repositorioPais;
        }


        public IViewComponentResult Invoke()
        {
            var paises = _repositorioPais.ObtenerTodos();
            return View(paises);
        }
    }
}
