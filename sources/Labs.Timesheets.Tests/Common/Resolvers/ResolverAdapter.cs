using System;
using Labs.Timesheets.Domain.Common.Adapters;
using Ninject;

namespace Labs.Timesheets.Tests.Common.Resolvers
{
    public class ResolverAdapter : IResolverAdapter
    {
        public ResolverAdapter(IKernel kernel)
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