using System;
using Labs.Timesheets.Common.Resolvers;
using Ninject;

namespace Labs.Timesheets.Adapters.Resolvers
{
    public class NinjectResolver : IResolver
    {
        public NinjectResolver(IKernel kernel)
        {
            Kernel = kernel;
        }

        protected IKernel Kernel { get; private set; }

        public object Get(Type type)
        {
            return Kernel.Get(type);
        }

        public T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}