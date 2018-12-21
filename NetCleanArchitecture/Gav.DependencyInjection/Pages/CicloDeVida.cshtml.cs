using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gav.DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gav.DependencyInjection.Pages
{
    public class CicloDeVidaModel : PageModel
    {
        public readonly OperationService _operationService;
        public string TransientDePagina { get; set; }
        public string ScopedDePagina { get; private set; }

        private readonly IOperationTransient _transientOperation;
        private readonly IOperationScoped _scopedOperation;
        private readonly IOperationSingleton _singletonOperation;
        private readonly IOperationSingletonInstance _singletonInstanceOperation;

        public string SingletonDePagina { get; private set; }
        public string SingletonInstanceDePagina { get; private set; }
        public string TransientDelServicio { get; }
        public string ScopedDelServicio { get; }
        public string SingletonDelServicio { get; }
        public string SingletonInstanceDelServicio { get; }


        public CicloDeVidaModel(OperationService operationService,
                                IOperationTransient transientOperation,
                                IOperationScoped scopedOperation,
                                IOperationSingleton singletonOperation,
                                IOperationSingletonInstance singletonInstanceOperation)
        {
            TransientDePagina = transientOperation.OperationId.ToString();
            ScopedDePagina = scopedOperation.OperationId.ToString();
            SingletonDePagina = singletonOperation.OperationId.ToString();
            SingletonInstanceDePagina = singletonInstanceOperation.OperationId.ToString();

            TransientDelServicio = operationService.TransientOperation.OperationId.ToString();
            ScopedDelServicio = operationService.ScopedOperation.OperationId.ToString();
            SingletonDelServicio = operationService.SingletonOperation.OperationId.ToString();
            SingletonInstanceDelServicio = operationService.SingletonInstanceOperation.OperationId.ToString();

            _operationService = operationService;
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
            _singletonInstanceOperation = singletonInstanceOperation;
        }

        public void OnGet()
        {

        }
    }
}