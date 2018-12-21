using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Gav.Logs.Services
{
    public interface IEmailService
    {
        void EnviarCorreo();
    }

    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger; 
        }

        public void EnviarCorreo()
        {
            _logger.LogWarning("Enviando Correo");
        }
    }
}
