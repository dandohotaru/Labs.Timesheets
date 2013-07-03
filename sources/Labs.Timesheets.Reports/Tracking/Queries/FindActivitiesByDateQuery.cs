using System;
using System.Collections.Generic;
using Labs.Timesheets.Reports.Common.Queries;
using Labs.Timesheets.Reports.Tracking.Models;

namespace Labs.Timesheets.Reports.Tracking.Queries
{
    public class FindActivitiesByDateQuery : QueryBase<FindActivitiesByDateResult>
    {
        public DateTimeOffset Reference { get; set; }

        public FindActivitiesByDateQuery ForTenant(Guid tenantId)
        {
            TenantId = tenantId;
            return this;
        }

        public FindActivitiesByDateQuery ForReference(DateTimeOffset date)
        {
            Reference = date;
            return this;
        }
    }

    public class FindActivitiesByDateResult : ResultBase
    {
        public List<ActivityInfo> Activities { get; set; }

        public FindActivitiesByDateResult Add(IEnumerable<ActivityInfo> activities)
        {
            if (Activities == null)
                Activities = new List<ActivityInfo>();
            Activities.AddRange(activities);
            return this;
        }
    }
}