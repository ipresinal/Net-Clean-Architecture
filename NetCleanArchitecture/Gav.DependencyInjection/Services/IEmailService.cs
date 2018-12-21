using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gav.DependencyInjection.Services
{
    public interface IEmailService
    {
        string EnviarCorreo();
    }
}
