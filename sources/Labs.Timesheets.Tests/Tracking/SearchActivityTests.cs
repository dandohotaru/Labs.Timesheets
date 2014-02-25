using System.Linq;
using Labs.Extensions;
using Labs.Timesheets.Reports.Messages;
using Labs.Timesheets.Tests.Common;
using Labs.Timesheets.Tests.Seeding;
using NUnit.Framework;

namespace Labs.Timesheets.Tests.Tracking
{
    [TestFixture]
    public class SearchActivityTests : Fixture
    {
        [Test]
        public void ShouldReturnActivitiesWhenActivitiesAreSearchedByDate()
        {
            // Given
            var query = new FindActivitiesByDateQuery()
                {
                    TenantId = JohnDoeStory.UserId,
                    Date = JohnDoeStory.Date,
                };

            // When
            var result = Querier.Search(query);

            // Then
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Activities, Is.Not.Null);
            Assert.That(result.Activities.Any(), Is.True);
            result.Activities.Dump();
        }
    }
}