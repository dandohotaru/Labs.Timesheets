using System;
using CommonServiceLocator.NinjectAdapter;
using Labs.Timesheets.Domain;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Tracking.Commands;
using Labs.Timesheets.Reports;
using Labs.Timesheets.Reports.Tracking.Queries;
using Labs.Timesheets.Storage.Mem.Contexts;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Labs.Timesheets.App.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<IStorageAdapter>().To<StorageAdapter>().InSingletonScope();
            kernel.Bind<Func<IStorageAdapter>>().ToMethod(context => (() => context.Kernel.Get<IStorageAdapter>()));
            kernel.Bind<IWriter>().To<Writer>();

            var locator = new NinjectServiceLocator(kernel);
            ServiceLocator.SetLocatorProvider(() => locator);

            var projectId = Guid.NewGuid();
            AddProjectTest(projectId);
            FindProjectTest(projectId);
        }

        private static void AddProjectTest(Guid projectId)
        {
            var addProjectCommand = new AddTagCommand
                                        {
                                            TagId = projectId,
                                            TagName = "Testing",
                                            TagNotes = "Here be dragons",
                                            InitiatorId = Guid.NewGuid(),
                                        };
            var dispatcher = ServiceLocator.Current.GetInstance<IWriter>();
            dispatcher.Execute(addProjectCommand);
        }

        private static void FindProjectTest(Guid projectId)
        {
            var dispatcher = ServiceLocator.Current.GetInstance<IReader>();
            var findProjectQuery = new FindTagsByIdsQuery()
                .AddTagId(projectId);
            var project = dispatcher
                .Execute(findProjectQuery);
            if (project == null)
                throw new Exception("The tag could not be found based on id");
        }
    }
}