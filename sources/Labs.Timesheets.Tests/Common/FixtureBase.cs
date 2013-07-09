﻿using System;
using Labs.Timesheets.Adapters.Resolvers;
using Labs.Timesheets.Common.Resolvers;
using Labs.Timesheets.Data.Mem.Contexts;
using Labs.Timesheets.Domain;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Handlers;
using Labs.Timesheets.Domain.Tracking.Commands;
using Labs.Timesheets.Domain.Tracking.Handlers;
using Labs.Timesheets.Reports;
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
            kernel.Bind<IStorageAdapter>().To<StorageAdapter>().InSingletonScope();
            kernel.Bind<Func<IStorageAdapter>>().ToMethod(context => (() => context.Kernel.Get<IStorageAdapter>()));
            kernel.Bind<IWriter>().To<Writer>().InSingletonScope();
            kernel.Bind<IReader>().To<Reader>().InSingletonScope();

            kernel.Bind<IWriteHandler<AddTagCommand>>().To<TagWriteHandler>();
            kernel.Bind<IWriteHandler<RemoveTagCommand>>().To<TagWriteHandler>();
            kernel.Bind<IWriteHandler<ModifyTagCommand>>().To<TagWriteHandler>();

            Resolver = kernel.Get<IResolver>();
            Reader = kernel.Get<IReader>();
            Writer = kernel.Get<IWriter>();
        }

        [SetUp]
        public virtual void TestSetUp()
        {
            Resolver
                .Get<IStorageAdapter>()
                .SeedJohnDoe()
                .SeedJackDoe()
                .Save();
        }

        [TearDown]
        public virtual void TestTearDown()
        {
            Resolver
                .Get<IStorageAdapter>()
                .Clear();
        }

        [TestFixtureTearDown]
        public virtual void FixtureTearDown()
        {
        }
    }
}