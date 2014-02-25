using System;
using System.Collections.Generic;
using Labs.Timesheets.Adapters.Dispatchers;
using Labs.Timesheets.Data.Mem.Write;
using Labs.Timesheets.Domain;
using Labs.Timesheets.Domain.Commands;
using Labs.Timesheets.Domain.Common;
using Labs.Timesheets.Reports;
using Labs.Timesheets.Reports.Messages;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Labs.Timesheets.App.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<IWriter>().To<MemWriter>().InSingletonScope();
            kernel.Bind<Func<IWriter>>().ToMethod(context => (() => context.Kernel.Get<IWriter>()));
            kernel.Bind<ICommander>().To<Commander>().InSingletonScope();
            kernel.Bind<IQuerier>().To<Querier>().InSingletonScope();

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
            var writer = ServiceLocator.Current.GetInstance<ICommander>();
            writer.Send(addTagCommand);
        }

        private static void FindProjectTest(Guid projectId)
        {
            var reader = ServiceLocator.Current.GetInstance<IQuerier>();
            var findProjectQuery = new FindTagsByIdsQuery
                {
                    TagIds = new List<Guid> {projectId},
                };
            var project = reader.Search(findProjectQuery);
            if (project == null)
                throw new Exception("The tag could not be found based on id");
        }
    }
}