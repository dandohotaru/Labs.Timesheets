using System.Linq;
using Labs.Timesheets.Reports.Tracking.Queries;
using Labs.Timesheets.Tests.Common;
using Labs.Timesheets.Tests.Common.Extensions;
using Labs.Timesheets.Tests.Seeding;
using NUnit.Framework;

namespace Labs.Timesheets.Tests.Tracking
{
    [TestFixture]
    public class ActivityTests : FixtureBase
    {
        [Test]
        public void WhenActivitiesAreSearchedThenActivitiesAreRetrieved()
        {
            // Given
            var date = JohnDoeStubs.Date;
            var query = new FindActivitiesByDateQuery()
                .ForTenant(JohnDoeStubs.UserId)
                .ForReference(date);

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