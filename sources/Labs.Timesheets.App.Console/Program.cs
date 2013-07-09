using System;
using Labs.Timesheets.Adapters.Locators;
using Labs.Timesheets.Data.Mem.Contexts;
using Labs.Timesheets.Domain;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Tracking.Commands;
using Labs.Timesheets.Reports;
using Labs.Timesheets.Reports.Tracking.Queries;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Labs.Timesheets.App.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<IStorage>().To<MemStorage>().InSingletonScope();
            kernel.Bind<Func<IStorage>>().ToMethod(context => (() => context.Kernel.Get<IStorage>()));
            kernel.Bind<IWriter>().To<Writer>().InSingletonScope();
            kernel.Bind<IReader>().To<Reader>().InSingletonScope();

            var locator = new NinjectLocator(kernel);
            ServiceLocator.SetLocatorProvider(() => locator);

            var projectId = Guid.NewGuid();
            AddProjectTest(projectId);
            FindProjectTest(projectId);
        }

        private static void AddProjectTest(Guid projectId)
        {
            var addTagCommand = new AddTagCommand
                                    {
                                        TagId = projectId,
                                        TagName = "Testing",
                                        TagNotes = "Here be dragons",
                                        InitiatorId = Guid.NewGuid(),
                                    };
            var writer = ServiceLocator.Current.GetInstance<IWriter>();
            writer.Send(addTagCommand);
        }

        private static void FindProjectTest(Guid projectId)
        {
            var reader = ServiceLocator.Current.GetInstance<IReader>();
            var findProjectQuery = new FindTagsByIdsQuery()
                .AddTagId(projectId);
            var project = reader
                .Fetch(findProjectQuery);
            if (project == null)
                throw new Exception("The tag could not be found based on id");
        }
    }
}