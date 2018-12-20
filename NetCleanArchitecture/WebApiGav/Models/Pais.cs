﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGav.Models
{
    public class Pais
    {
        public Pais()
        {
            Provincias = new List<Provincia>();
        }

        public int Id { get; set; }

        [StringLength(30)]
        public string Nombre { get; set; }

        public List<Provincia> Provincias { get; set; }
    }
}
