using System;
using System.Collections.Generic;
using CustomerApp.Infrastructure.Data.SqlHelper;
using HolaMundo.Models;

namespace HolaMundo.Services
{
    public interface IRepositorioPais
    {
         List<Pais> ObtenerTodos();
    }
}
