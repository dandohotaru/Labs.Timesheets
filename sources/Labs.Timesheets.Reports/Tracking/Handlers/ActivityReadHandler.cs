﻿using System.Linq;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Tracking.Entities;
using Labs.Timesheets.Reports.Common.Handlers;
using Labs.Timesheets.Reports.Tracking.Models;
using Labs.Timesheets.Reports.Tracking.Queries;

namespace Labs.Timesheets.Reports.Tracking.Handlers
{
    public class ActivityReadHandler
        : IReadHandler<FindActivitiesByDateQuery, FindActivitiesByDateResult>
    {
        public ActivityReadHandler(IStorageAdapter context)
        {
            Context = context;
        }

        protected IStorageAdapter Context { get; set; }

        public FindActivitiesByDateResult Handle(FindActivitiesByDateQuery request)
        {
            var query = from activity in Context.Query<Activity>()
                        where activity.TenantId == request.TenantId
                        where activity.Start.Date <= request.Reference.Date
                              && activity.End.Date >= request.Reference.Date
                        select activity;

            var details = from activity in query
                          select new ActivityInfo
                                     {
                                         Id = activity.Id,
                                         Start = activity.Start,
                                         End = activity.End,
                                         Notes = activity.Notes,
                                     };

            return new FindActivitiesByDateResult().Add(details);
        }
    }
}