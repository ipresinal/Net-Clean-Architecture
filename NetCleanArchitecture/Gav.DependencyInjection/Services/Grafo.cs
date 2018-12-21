using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gav.DependencyInjection.Services
{
    public interface IServicioA
    {
        string ObtenerMensaje();
    }

    public interface IServicioB {}
    public interface IServicioC { }
    public interface IServicioD { }

    public class ServicioA : IServicioA
    {
        public ServicioA(IServicioB servicioB, IServicioC servicioC)
        {
            
        }

        public string ObtenerMensaje()
        {
            return "Mensaje desde el servicio A";
        }
    }

    public class ServicioB : IServicioB
    {
        public ServicioB(IServicioC servicioC, IServicioD servicioD)
        {

        }
      
    }

    public class ServicioC : IServicioC
    {       
    }

    public class ServicioD : IServicioD
    {
        public ServicioD(IServicioC servicioC)
        {
            
        }
    }

    
}
