using System.Linq;
using Labs.Timesheets.Reports.Tracking.Queries;
using Labs.Timesheets.Tests.Common;
using Labs.Timesheets.Tests.Seeding.Stories;
using NUnit.Framework;

namespace Labs.Timesheets.Tests.Tracking
{
    [TestFixture]
    public class SearchActivityTests : FixtureBase
    {
        [Test]
        public void ShouldReturnActivitiesWhenActivitiesAreSearchedByDate()
        {
            // Given
            var query = new FindActivitiesByDateQuery()
                .ForTenant(JohnDoeStory.UserId)
                .ForReference(JohnDoeStory.Date);

            // When
            var result = Reader.Fetch(query);

            // Then
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Activities, Is.Not.Null);
            Assert.That(result.Activities.Any(), Is.True);
            result.Activities.Dump();
        }
    }
}