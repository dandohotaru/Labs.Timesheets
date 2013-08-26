using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Timesheets.Reports.Common.Queries;
using Labs.Timesheets.Reports.Tracking.Models;

namespace Labs.Timesheets.Reports.Tracking.Queries
{
    public class FindActivitiesByDateQuery : QueryBase<FindActivitiesByDateQuery, FindActivitiesByDateResult>
    {
        public DateTimeOffset Date { get; protected set; }

        public FindActivitiesByDateQuery ForDate(DateTimeOffset date)
        {
            Date = date;
            return this;
        }
    }

    public class FindActivitiesByDateResult : ResultBase
    {
        public FindActivitiesByDateResult(IEnumerable<ActivityInfo> activities)
        {
            if (activities == null)
                throw new ArgumentNullException("activities");
            Activities = activities.ToList();
        }

        public List<ActivityInfo> Activities { get; protected set; }
    }
}