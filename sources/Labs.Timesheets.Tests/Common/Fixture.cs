using System;
using Labs.Timesheets.Adapters.Dispatchers;
using Labs.Timesheets.Data.Mem.Read;
using Labs.Timesheets.Data.Mem.Write;
using Labs.Timesheets.Domain;
using Labs.Timesheets.Domain.Common;
using Labs.Timesheets.Reports;
using Labs.Timesheets.Reports.Common;
using Labs.Timesheets.Tests.Seeding;
using NUnit.Framework;
using Ninject;
using Ninject.Extensions.Conventions;

namespace Labs.Timesheets.Tests.Common
{
    [TestFixture]
    public abstract class Fixture
    {
        public IKernel Locator { get; set; }
        protected IQuerier Querier { get; set; }
        protected ICommander Commander { get; set; }

        [TestFixtureSetUp]
        public virtual void FixtureSetUp()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IWriter>>().ToMethod(context => (() => new MemWriter()));
            kernel.Bind<Func<IReader>>().ToMethod(context => (() => new MemReader()));
            kernel.Bind<ICommander>().To<Commander>();
            kernel.Bind<IQuerier>().To<Querier>();

            kernel.Bind(p => p.FromAssemblyContaining(typeof (IHandler<>))
                              .SelectAllClasses()
                              .InheritedFrom(typeof (IHandler<>))
                              .BindAllInterfaces());

            kernel.Bind(p => p.FromAssemblyContaining(typeof (IHandler<,>))
                              .SelectAllClasses()
                              .InheritedFrom(typeof (IHandler<,>))
                              .BindAllInterfaces());

            Querier = kernel.Get<IQuerier>();
            Commander = kernel.Get<ICommander>();
            Locator = kernel;
        }

        [SetUp]
        public virtual void TestSetUp()
        {
            using (var context = Locator.Get<Func<IWriter>>()())
            {
                var johnDoeStory = new JohnDoeStory(context);
                johnDoeStory.Build();

                var jackDoeStory = new JackDoeStory(context);
                jackDoeStory.Build();

                context.Save();
            }
        }

        [TearDown]
        public virtual void TestTearDown()
        {
            using (var context = Locator.Get<Func<IWriter>>()())
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