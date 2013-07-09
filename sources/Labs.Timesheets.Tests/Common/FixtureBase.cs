using System;
using Labs.Timesheets.Adapters.Resolvers;
using Labs.Timesheets.Common.Resolvers;
using Labs.Timesheets.Data.Mem.Contexts;
using Labs.Timesheets.Domain;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Handlers;
using Labs.Timesheets.Domain.Tracking.Commands;
using Labs.Timesheets.Domain.Tracking.Handlers;
using Labs.Timesheets.Reports;
using Labs.Timesheets.Reports.Common.Handlers;
using Labs.Timesheets.Reports.Tracking.Handlers;
using Labs.Timesheets.Reports.Tracking.Queries;
using Labs.Timesheets.Tests.Seeding;
using NUnit.Framework;
using Ninject;

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

            kernel.Bind<IWriteHandler<AddTagCommand>>().To<TagWriteHandler>();
            kernel.Bind<IWriteHandler<RemoveTagCommand>>().To<TagWriteHandler>();
            kernel.Bind<IWriteHandler<ModifyTagCommand>>().To<TagWriteHandler>();

            kernel.Bind<IReadHandler<FindTagsByIdsQuery, FindTagsByIdsResult>>().To<TagReadHandler>();
            kernel.Bind<IReadHandler<FindTagsByTextQuery, FindTagsByTextResult>>().To<TagReadHandler>();
            kernel.Bind<IReadHandler<FindActivitiesByDateQuery, FindActivitiesByDateResult>>().To<ActivityReadHandler>();

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