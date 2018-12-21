using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gav.DependencyInjection.Services
{
    public interface IOperation
    {
        Guid OperationId { get; }
    }

    public class Operations : IOperationScoped, IOperationSingleton, IOperationTransient, IOperationSingletonInstance
    {
        private Guid _guid;
        public Guid OperationId{get { return _guid; }}

        public Operations()
        {
            _guid = Guid.NewGuid();
        }

        public Operations(Guid guid)
        {
            _guid = guid;
        }

        
    }

    public interface IOperationTransient : IOperation
    {       
    }
    public interface IOperationScoped : IOperation
    {
    }

    public interface IOperationSingleton : IOperation
    {
    }

    public interface IOperationSingletonInstance : IOperation
    {
    }

}
