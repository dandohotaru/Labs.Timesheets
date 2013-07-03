using System;
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
        public void WhenActivitiesAreSearchedThenActivitiesCanBeRetrieved()
        {
            // Given
            var today = JohnDoeStubs.Date;
            var query = new FindActivitiesByDateQuery()
                .ForTenant(JohnDoeStubs.UserId)
                .ForReference(today);

            // When
            var result = Reader.Execute(query);

            // Then
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Any(), Is.True);
            result.Activities.Dump();
        }
    }
}