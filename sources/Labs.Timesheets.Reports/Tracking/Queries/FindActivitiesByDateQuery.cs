using System;
using System.Collections;
using System.Collections.Generic;
using Labs.Timesheets.Reports.Common.Queries;
using Labs.Timesheets.Reports.Tracking.Models;

namespace Labs.Timesheets.Reports.Tracking.Queries
{
    public class FindActivitiesByDateQuery : QueryBase<FindActivitiesByDateResult>
    {
        public DateTimeOffset Date { get; private set; }

        public FindActivitiesByDateQuery ForDate(DateTimeOffset date)
        {
            Date = date;
            return this;
        }
    }

    public class FindActivitiesByDateResult : ResultBase, IEnumerable<ActivityDetail>
    {
        public List<ActivityDetail> Activities { get; private set; }

        public FindActivitiesByDateResult Add(ActivityDetail activity)
        {
            if (Activities == null)
                Activities = new List<ActivityDetail>();
            Activities.Add(activity);
            return this;
        }

        public FindActivitiesByDateResult Add(IEnumerable<ActivityDetail> activities)
        {
            if (Activities == null)
                Activities = new List<ActivityDetail>();
            foreach (var tag in activities)
            {
                Activities.Add(tag);
            }
            return this;
        }

        public IEnumerator<ActivityDetail> GetEnumerator()
        {
            if (Activities == null)
                Activities = new List<ActivityDetail>();
            return Activities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}