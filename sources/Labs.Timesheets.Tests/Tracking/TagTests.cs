using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Timesheets.Common.Extensions;
using Labs.Timesheets.Domain.Common.Commands;
using Labs.Timesheets.Domain.Tracking.Commands;
using Labs.Timesheets.Reports.Tracking.Queries;
using Labs.Timesheets.Tests.Common;
using NUnit.Framework;

namespace Labs.Timesheets.Tests.Tracking
{
    [TestFixture]
    public class TagTests : FixtureBase
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
            Writer.Send(addTagCommand);

            // When
            var removedTagCommand = new RemoveTagCommand
                                        {
                                            TagId = tagId,
                                        };
            Writer.Send(removedTagCommand);

            // Then
            var findTagsByIdsQuery = new FindTagsByIdsQuery()
                .AddTagId(tagId);
            var result = Reader
                .Search(findTagsByIdsQuery)
                .SingleOrDefault();
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
            Writer.Send(addTagCommand);

            // Then l
            var findTagsByIdsQuery = new FindTagsByIdsQuery()
                .AddTagId(tagId);
            var result = Reader
                .Search(findTagsByIdsQuery)
                .Single();
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
            Writer.Send(commands);

            // Then 
            var findTagsByIdsQuery = new FindTagsByIdsQuery()
                .AddTagId(firstCommand.TagId)
                .AddTagId(secondCommand.TagId);
            var result = Reader
                .Search(findTagsByIdsQuery);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Tags, Is.Not.Null);
            Assert.That(result.Tags.Count, Is.EqualTo(1));
        }
    }
}