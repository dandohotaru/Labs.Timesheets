using System;
using System.Linq;
using Labs.Timesheets.Reports.Tracking.Queries;
using Labs.Timesheets.Tests.Common;
using Labs.Timesheets.Tests.Common.Extensions;
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
            var today = DateTime.Now.ToUniversalTime().Date;
            var query = new FindActivitiesByDateQuery()
                .ForDate(today);

            // When
            var result = Reader.Execute(query);

            // Then
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Any(), Is.True);
            result.Activities.Dump();
        }
    }
}