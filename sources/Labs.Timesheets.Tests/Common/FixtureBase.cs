using System;
using CommonServiceLocator.NinjectAdapter;
using Labs.Timesheets.Domain;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Handlers;
using Labs.Timesheets.Domain.Tracking.Commands;
using Labs.Timesheets.Domain.Tracking.Handlers;
using Labs.Timesheets.Reports;
using Labs.Timesheets.Storage.Mem.Contexts;
using Labs.Timesheets.Tests.Common.Resolvers;
using Labs.Timesheets.Tests.Seeding;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using Ninject;

namespace Labs.Timesheets.Tests.Common
{
    [TestFixture]
    public abstract class FixtureBase
    {
        protected IReader Reader { get; set; }
        protected IWriter Writer { get; set; }

        [TestFixtureSetUp]
        public virtual void FixtureSetUp()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IResolverAdapter>().To<ResolverAdapter>().InSingletonScope();
            kernel.Bind<IStorageAdapter>().To<StorageAdapter>().InSingletonScope();
            kernel.Bind<Func<IStorageAdapter>>().ToMethod(context => (() => context.Kernel.Get<IStorageAdapter>()));
            kernel.Bind<IWriter>().To<Writer>().InSingletonScope();
            kernel.Bind<IReader>().To<Reader>().InSingletonScope();

            var locator = new NinjectServiceLocator(kernel);
            ServiceLocator.SetLocatorProvider(() => locator);

            Reader = kernel.Get<IReader>();
            Writer = kernel.Get<IWriter>()
                .Register<AddTagCommand, TagWriteHandler>()
                .Register<RemoveTagCommand, TagWriteHandler>()
                .Register<ModifyTagCommand, TagWriteHandler>();
        }

        [SetUp]
        public virtual void TestSetUp()
        {
            ServiceLocator.Current
                .GetInstance<IStorageAdapter>()
                .SeedJohnDoe()
                .SeedJackDoe()
                .Save();
        }

        [TearDown]
        public virtual void TestTearDown()
        {
            ServiceLocator.Current
                .GetInstance<IStorageAdapter>()
                .Clear();
        }

        [TestFixtureTearDown]
        public virtual void FixtureTearDown()
        {
        }
    }
}