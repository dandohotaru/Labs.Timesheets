using System.Linq;
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
                        let activityDate = activity.Date.ToUniversalTime().Date
                        let requestDate = request.Date.ToUniversalTime().Date
                        where activityDate == requestDate
                        select activity;

            var views = from activity in query
                        select new ActivityDetail
                                   {
                                       Id = activity.Id,
                                       Date = activity.Date,
                                       Start = activity.Period.Start,
                                       End = activity.Period.End,
                                       Notes = activity.Notes,
                                   };

            return new FindActivitiesByDateResult().Add(views);
        }
    }
}