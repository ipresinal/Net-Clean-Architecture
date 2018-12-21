using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gav.Logs.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Gav.Logs.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmailService _emailService;
        private readonly Serilog.ILogger _seriLogger;

        public IndexModel(ILogger<IndexModel> logger, IEmailService emailService, Serilog.ILogger seriLoger)
        {
            _logger = logger;
            _emailService = emailService;
            _seriLogger = seriLoger;
        }

        public void OnGet()
        {
            _logger.LogDebug("Este es un mensaje debug");
            _logger.LogWarning("Este es un mensaje de warning");
            _logger.LogError("Este es un mensaje de error");

            _seriLogger.Error("Este es un mensaje de error");

            _emailService.EnviarCorreo();
        }
    }
}
