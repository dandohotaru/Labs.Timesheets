using System.Linq;
using Labs.Timesheets.Reports.Common;
using Labs.Timesheets.Reports.Entities;
using Labs.Timesheets.Reports.Messages;
using Labs.Timesheets.Reports.Models;

namespace Labs.Timesheets.Reports.Handlers
{
    public class ActivityReadHandler
        : IHandler<FindActivitiesByDateQuery, FindActivitiesByDateResult>
    {
        public ActivityReadHandler(IReader context)
        {
            Context = context;
        }

        protected IReader Context { get; private set; }

        public FindActivitiesByDateResult Handle(FindActivitiesByDateQuery request)
        {
            var query = from activity in Context.Query<Activity>()
                        where activity.TenantId == request.TenantId
                        where activity.Start <= request.Date
                              && activity.End >= request.Date
                        select activity;

            var details = from activity in query
                          select new ActivityModel
                                     {
                                         Id = activity.Id,
                                         Start = activity.Start,
                                         End = activity.End,
                                         Name = activity.Name,
                                         Notes = activity.Notes,
                                     };

            return new FindActivitiesByDateResult().AddActivities(details.ToList());
        }
    }
}