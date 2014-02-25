using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Extensions;
using Labs.Timesheets.Domain.Commands;
using Labs.Timesheets.Domain.Common;
using Labs.Timesheets.Reports.Messages;
using Labs.Timesheets.Tests.Common;
using NUnit.Framework;

namespace Labs.Timesheets.Tests.Tracking
{
    [TestFixture]
    public class AddTagTests : Fixture
    {
        [Test]
        public void WhenTagIsAddedThenProjectCanBeRemoved()
        {
            // Given
            var tagId = Guid.NewGuid();
            var addTagCommand = new AddTagCommand
                {
                    TagId = tagId,
                    TagName = "TestProject",
                    TagNotes = "Here be dragons",
                };
            Commander.Send(addTagCommand);

            // When
            var removedTagCommand = new RemoveTagCommand
                {
                    TagId = tagId,
                };
            Commander.Send(removedTagCommand);

            // Then
            var findTagsByIdsQuery = new FindTagsByIdsQuery
                {
                    TagIds = new List<Guid> {tagId},
                };
            var result = Querier
                .Search(findTagsByIdsQuery)
                .Tags.SingleOrDefault();
            Assert.That(result, Is.Null);
        }

        [Test]
        public void WhenTagIsAddedThenProjectCanBeRetrieved()
        {
            // Given
            var tagId = Guid.NewGuid();
            var addTagCommand = new AddTagCommand
                {
                    TagId = tagId,
                    TagName = "TestProject",
                    TagNotes = "Here be dragons",
                };

            // When
            Commander.Send(addTagCommand);

            // Then l
            var findTagsByIdsQuery = new FindTagsByIdsQuery
                {
                    TagIds = new List<Guid> {tagId},
                };
            var result = Querier
                .Search(findTagsByIdsQuery)
                .Tags.Single();
            Assert.That(result.TagId, Is.EqualTo(tagId));
        }

        [Test]
        public void WhenTagIsAddedTwiceThenProjectIsNotDuplicated()
        {
            // Given
            var tagId = Guid.NewGuid();
            var firstCommand = new AddTagCommand
                {
                    TagId = tagId,
                    TagName = "TestProject",
                    TagNotes = "Here be dragons",
                };

            // When
            var secondCommand = firstCommand.Clone();
            var commands = new List<ICommand>
                {
                    firstCommand,
                    secondCommand,
                };
            Commander.Send(commands);

            // Then 
            var findTagsByIdsQuery = new FindTagsByIdsQuery
                {
                    TagIds = new List<Guid>
                        {
                            firstCommand.TagId,
                            secondCommand.TagId,
                        }
                };
            var result = Querier.Search(findTagsByIdsQuery);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Tags, Is.Not.Null);
            Assert.That(result.Tags.Count, Is.EqualTo(1));
        }
    }
}