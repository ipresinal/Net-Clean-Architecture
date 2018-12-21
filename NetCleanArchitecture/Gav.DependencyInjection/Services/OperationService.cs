using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gav.DependencyInjection.Services
{
    public class OperationService
    {
        public IOperationTransient TransientOperation { get; }
        public IOperationScoped ScopedOperation { get; }
        public IOperationSingleton SingletonOperation { get; }
        public IOperationSingletonInstance SingletonInstanceOperation { get; }

        public OperationService(
            IOperationTransient transientOperation,
            IOperationSingleton singletonOperation,
            IOperationScoped scopedOperation,
            IOperationSingletonInstance instanceOperation)
        {
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
            SingletonInstanceOperation = instanceOperation;
        }
    }
}
