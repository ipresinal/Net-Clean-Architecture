using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HolaMundo.Models;
using HolaMundo.Services;

namespace HolaMundo.Controllers
{
    public class HomeController : Controller
    {
        public IRepositorioPais Repositorio { get; }


        public HomeController(IRepositorioPais repositorio)
        {
            Repositorio = repositorio;
        }


        public IActionResult Index()
        {           
            var paises = Repositorio.ObtenerTodos();
            return View(paises);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
