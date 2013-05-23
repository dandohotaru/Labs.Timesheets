using System;
using CommonServiceLocator.NinjectAdapter;
using Labs.Timesheets.Contracts.Common.Queries;
using Labs.Timesheets.Contracts.Core.Commands;
using Labs.Timesheets.Contracts.Core.Queries;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Core;
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
            kernel.Bind<IDispatcher>().To<Dispatcher>();

            var locator = new NinjectServiceLocator(kernel);
            ServiceLocator.SetLocatorProvider(() => locator);

            var projectId = Guid.NewGuid();
            AddProjectTest(projectId);
            FindProjectTest(projectId);
        }

        private static void AddProjectTest(Guid projectId)
        {
            var addProjectCommand = new AddProjectCommand
                                        {
                                            ProjectId = projectId,
                                            ProjectName = "Testing",
                                            ProjectNote = "Here be dragons",
                                            InitiatorId = Guid.NewGuid(),
                                        };
            var dispatcher = ServiceLocator.Current.GetInstance<IDispatcher>();
            dispatcher.Execute(addProjectCommand);
        }

        private static void FindProjectTest(Guid projectId)
        {
            var dispatcher = ServiceLocator.Current.GetInstance<IDispatcher>();
            var findProjectQuery = new FindProjectsByIdsQuery()
                .AddProjectId(projectId);
            var project = dispatcher
                .Execute(findProjectQuery)
                .Return<FindProjectsByIdsResult>();
            if (project == null)
                throw new Exception("The project could not be found based on id");
        }
    }
}