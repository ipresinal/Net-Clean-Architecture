using System;
using System.Collections.Generic;
using HolaMundo.Models;

namespace HolaMundo.Services
{
    public interface IRepositorioPais
    {
         List<Pais> ObtenerTodos();
    }
}
