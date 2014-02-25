using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Ninject.Parameters;

namespace Labs.Timesheets.Adapters.Dispatchers
{
    public class NinjectLocator : ServiceLocatorImplBase
    {
        public NinjectLocator(IKernel kernel)
        {
            Kernel = kernel;
        }

        protected IKernel Kernel { get; private set; }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return Kernel.Get(serviceType, key, new IParameter[0]);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return Kernel.GetAll(serviceType, new IParameter[0]);
        }
    }
}