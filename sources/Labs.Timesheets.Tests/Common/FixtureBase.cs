using System;
using Labs.Timesheets.Adapters.Dispatchers;
using Labs.Timesheets.Adapters.Resolvers;
using Labs.Timesheets.Data.Mem.Contexts;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Handlers;
using Labs.Timesheets.Reports.Common.Handlers;
using Labs.Timesheets.Tests.Seeding.Stories;
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
        protected IStorage Storage { get; set; }

        [TestFixtureSetUp]
        public virtual void FixtureSetUp()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IResolver>().To<NinjectResolver>().InSingletonScope();
            kernel.Bind<IStorage>().To<MemStorage>().InSingletonScope();
            kernel.Bind<Func<IStorage>>().ToMethod(context => (() => context.Kernel.Get<IStorage>()));
            kernel.Bind<IWriter>().To<Writer>();
            kernel.Bind<IReader>().To<Reader>();

            kernel.Bind(p => p
                .FromAssemblyContaining(typeof(IWriteHandler<>))
                .SelectAllClasses()
                .InheritedFrom(typeof (IWriteHandler<>))
                .BindAllInterfaces());

            kernel.Bind(p => p
                .FromAssemblyContaining(typeof(IReadHandler<,>))
                .SelectAllClasses()
                .InheritedFrom(typeof (IReadHandler<,>))
                .BindAllInterfaces());

            Resolver = kernel.Get<IResolver>();
            Reader = kernel.Get<IReader>();
            Writer = kernel.Get<IWriter>();
            Storage = kernel.Get<IStorage>();
        }

        [SetUp]
        public virtual void TestSetUp()
        {
            using (var context = Resolver.Get<IStorage>())
            {
                var johnDoeStory = new JohnDoeStory(context);
                johnDoeStory.Seed();

                var jackDoeStory = new JackDoeStory(context);
                jackDoeStory.Seed();

                context.Save();
            }
        }

        [TearDown]
        public virtual void TestTearDown()
        {
            using (var context = Resolver.Get<IStorage>())
            {
                context.Clear();
                context.Save();
            }
        }

        [TestFixtureTearDown]
        public virtual void FixtureTearDown()
        {
        }
    }
}