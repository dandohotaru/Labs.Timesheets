using System.Linq;
using Labs.Timesheets.Contracts.Tracking.Models;
using Labs.Timesheets.Contracts.Tracking.Queries;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Tracking.Entities;
using Labs.Timesheets.Reports.Common.Handlers;

namespace Labs.Timesheets.Reports.Tracking.Handlers
{
    public class TimesheetReadHandler
        : IReadHandler<FindTimesheetByIdQuery, FindTimesheetByIdResult>,
          IReadHandler<FindTimesheetsByTextQuery, FindTimesheetsByTextResult>
    {
        public TimesheetReadHandler(IStorageAdapter context)
        {
            Context = context;
        }

        protected IStorageAdapter Context { get; set; }

        public FindTimesheetByIdResult Handle(FindTimesheetByIdQuery query)
        {
            var results = from timesheet in Context.Query<Timesheet>()
                          where timesheet.Id == query.TimesheetId
                          select new FindTimesheetByIdResult
                                     {
                                         Timesheet = new TimesheetDetail
                                                         {
                                                             Id = timesheet.Id,
                                                             Name = timesheet.Name,
                                                         },
                                     };

            return results.SingleOrDefault();
        }

        public FindTimesheetsByTextResult Handle(FindTimesheetsByTextQuery query)
        {
            var timesheets = from timesheet in Context.Query<Timesheet>()
                             where timesheet.Name == query.SearchText
                                   || timesheet.Notes == query.SearchText
                             select new TimesheetBrief
                                        {
                                            Id = timesheet.Id,
                                            Name = timesheet.Name,
                                        };

            var results = new FindTimesheetsByTextResult()
                .Add(timesheets);

            return results;
        }

        public FindTimesheetsByCriteriaResult Handle(FindTimesheetsByCriteriaQuery query)
        {
            var selector = Context.Query<Timesheet>();

            if (query.OwnerId != null)
            {
                selector = from timesheet in selector
                           where timesheet.OwnerId == query.OwnerId
                           select timesheet;
            }

            if (query.Coverage != null)
            {
                selector = from timesheet in selector
                           from activity in timesheet.Days
                           where query.Coverage.From <= activity.Reference
                           where query.Coverage.To >= activity.Reference
                           select timesheet;
            }

            if (query.SearchText != null)
            {
                selector = from timesheet in selector
                           where timesheet.Name.Contains(query.SearchText)
                           where timesheet.Notes.Contains(query.SearchText)
                           select timesheet;
            }

            var timesheets = from timesheet in selector
                             select new TimesheetBrief
                                        {
                                            Id = timesheet.Id,
                                            Name = timesheet.Name,
                                        };

            var results = new FindTimesheetsByCriteriaResult()
                .Add(timesheets);

            return results;
        }
    }
}