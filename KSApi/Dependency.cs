using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSApi
{
    public interface ISingletonOperation
    {
        public Guid ID { get; }
    }
    public interface IScopedOperation
    {
        public Guid ID { get; }
    }
    public interface ITransientOperation
    {
        public Guid ID { get; }
    }

    public class Operation :ISingletonOperation,IScopedOperation,ITransientOperation
    {
        public Guid ID { get; }

        public Operation()
        {
            ID = Guid.NewGuid();
        }
    }
}
