using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Timesheets.Contracts.Common.Commands;
using Labs.Timesheets.Contracts.Core.Commands;
using Labs.Timesheets.Contracts.Core.Queries;
using Labs.Timesheets.Domain.Common.Extensions;
using Labs.Timesheets.Tests.Common;
using NUnit.Framework;

namespace Labs.Timesheets.Tests.Core
{
    [TestFixture]
    public class ProjectTests : FixtureBase
    {
        [Test]
        public void WhenProjectIsAddedThenProjectCanBeRemoved()
        {
            // Given
            var projectId = Guid.NewGuid();
            var addProjectCommand = new AddProjectCommand
                                        {
                                            ProjectId = projectId,
                                            ProjectName = "TestProject",
                                            ProjectNote = "Here be dragons",
                                        };
            Dispatcher.Execute(addProjectCommand);

            // When
            var removeProjectCommand = new RemovedProjectCommand
                                           {
                                               ProjectId = projectId,
                                           };
            Dispatcher.Execute(removeProjectCommand);

            // Then
            var findProjectsByIdsQuery = new FindProjectsByIdsQuery()
                .AddProjectId(projectId);
            var result = Dispatcher
                .Execute(findProjectsByIdsQuery)
                .SingleOrDefault();
            Assert.That(result, Is.Null);
        }

        [Test]
        public void WhenProjectIsAddedThenProjectCanBeRetrieved()
        {
            // Given
            var projectId = Guid.NewGuid();
            var addProjectCommand = new AddProjectCommand
                                        {
                                            ProjectId = projectId,
                                            ProjectName = "TestProject",
                                            ProjectNote = "Here be dragons",
                                        };

            // When
            Dispatcher.Execute(addProjectCommand);

            // Then l
            var findProjectsByIdsQuery = new FindProjectsByIdsQuery()
                .AddProjectId(projectId);
            var result = Dispatcher
                .Execute(findProjectsByIdsQuery)
                .Single();
            Assert.That(result.ProjectId, Is.EqualTo(projectId));
        }

        [Test]
        public void WhenProjectIsAddedTwiceThenProjectIsNotDuplicated()
        {
            // Given
            var projectId = Guid.NewGuid();
            var firstCommand = new AddProjectCommand
                                   {
                                       ProjectId = projectId,
                                       ProjectName = "TestProject",
                                       ProjectNote = "Here be dragons",
                                   };

            // When
            var secondCommand = firstCommand.Clone();
            var commands = new List<ICommand>
                               {
                                   firstCommand,
                                   secondCommand,
                               };
            Dispatcher.Execute(commands);

            // Then 
            var findProjectByIdsQuery = new FindProjectsByIdsQuery()
                .AddProjectId(firstCommand.ProjectId)
                .AddProjectId(secondCommand.ProjectId);
            var result = Dispatcher
                .Execute(findProjectByIdsQuery);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Projects, Is.Not.Null);
            Assert.That(result.Projects.Count, Is.EqualTo(1));
        }
    }
}