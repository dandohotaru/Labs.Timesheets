using System;
using CommonServiceLocator.NinjectAdapter;
using Labs.Timesheets.Domain;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Core;
using Labs.Timesheets.Storage.Mem.Contexts;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using Ninject;

namespace Labs.Timesheets.Tests.Common
{
    [TestFixture]
    public abstract class FixtureBase
    {
        [SetUp]
        public virtual void TestSetUp()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IStorageAdapter>().To<StorageAdapter>().InSingletonScope();
            kernel.Bind<Func<IStorageAdapter>>().ToMethod(context => (() => context.Kernel.Get<IStorageAdapter>()));
            kernel.Bind<IDispatcher>().To<Dispatcher>();

            var locator = new NinjectServiceLocator(kernel);
            ServiceLocator.SetLocatorProvider(() => locator);
        }

        [TearDown]
        public virtual void TestTearDown()
        {
        }

        [TestFixtureSetUp]
        public virtual void FixtureSetUp()
        {
        }

        [TestFixtureTearDown]
        public virtual void FixtureTearDown()
        {
        }
    }
}