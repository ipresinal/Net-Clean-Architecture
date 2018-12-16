using System;
using System.Collections.Generic;
using HolaMundo.Models;


namespace HolaMundo.Services
{
    public class PaisrepositorioEnMemoria : IRepositorioPais
    {
        public List<Pais> ObtenerTodos()
        {
            List<Pais> paises = new List<Pais>()
            {
                new Pais("Republica Dominicana"),
                new Pais("México"),
                new Pais("Colombia"),
                new Pais("Costa Rica")
            };
            return paises;
        }
    }
}
