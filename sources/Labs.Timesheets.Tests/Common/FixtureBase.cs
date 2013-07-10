using System;
using Labs.Timesheets.Adapters.Dispatchers;
using Labs.Timesheets.Adapters.Resolvers;
using Labs.Timesheets.Common.Resolvers;
using Labs.Timesheets.Data.Mem.Contexts;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Handlers;
using Labs.Timesheets.Reports.Common.Handlers;
using Labs.Timesheets.Tests.Seeding;
using NUnit.Framework;
using Ninject;
using Ninject.Extensions.Conventions;

namespace Labs.Timesheets.Tests.Common
{
    [TestFixture]
    public abstract class FixtureBase
    {
        protected IResolver Resolver { get; set; }
        protected IReader Reader { get; set; }
        protected IWriter Writer { get; set; }

        [TestFixtureSetUp]
        public virtual void FixtureSetUp()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IResolver>().To<NinjectResolver>().InSingletonScope();
            kernel.Bind<IStorage>().To<MemStorage>().InSingletonScope();
            kernel.Bind<Func<IStorage>>().ToMethod(context => (() => context.Kernel.Get<IStorage>()));
            kernel.Bind<IWriter>().To<Writer>().InSingletonScope();
            kernel.Bind<IReader>().To<Reader>().InSingletonScope();

            kernel.Bind(p => p
                .FromAssemblyContaining<IWriter>()
                .SelectAllClasses()
                .InheritedFrom(typeof (IWriteHandler<>))
                .BindAllInterfaces());

            kernel.Bind(p => p
                .FromAssemblyContaining<IReader>()
                .SelectAllClasses()
                .InheritedFrom(typeof (IReadHandler<,>))
                .BindAllInterfaces());

            Resolver = kernel.Get<IResolver>();
            Reader = kernel.Get<IReader>();
            Writer = kernel.Get<IWriter>();
        }

        [SetUp]
        public virtual void TestSetUp()
        {
            Resolver
                .Get<IStorage>()
                .SeedJohnDoe()
                .SeedJackDoe()
                .Save();
        }

        [TearDown]
        public virtual void TestTearDown()
        {
            Resolver.Get<IStorage>().Clear();
        }

        [TestFixtureTearDown]
        public virtual void FixtureTearDown()
        {
        }
    }
}