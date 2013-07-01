using System.Linq;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Tracking.Entities;
using Labs.Timesheets.Reports.Common.Handlers;
using Labs.Timesheets.Reports.Tracking.Models;
using Labs.Timesheets.Reports.Tracking.Queries;

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

        public FindTimesheetByIdResult Handle(FindTimesheetByIdQuery request)
        {
            var query = from timesheet in Context.Query<Timesheet>()
                        where timesheet.Id == request.TimesheetId
                        select timesheet;

            var data = from timesheet in query
                       select new TimesheetDetail
                                  {
                                      Id = timesheet.Id,
                                      Name = timesheet.Name,
                                  };

            var result = new FindTimesheetByIdResult()
                .Set(data.SingleOrDefault());

            return result;
        }

        public FindTimesheetsByTextResult Handle(FindTimesheetsByTextQuery request)
        {
            var query = from timesheet in Context.Query<Timesheet>()
                        where timesheet.Name == request.SearchText
                              || timesheet.Notes == request.SearchText
                        select timesheet;

            var data = from timesheet in query
                       select new TimesheetBrief
                                  {
                                      Id = timesheet.Id,
                                      Name = timesheet.Name,
                                  };

            var results = new FindTimesheetsByTextResult()
                .Add(data);

            return results;
        }

        public FindTimesheetsByCriteriaResult Handle(FindTimesheetsByCriteriaQuery request)
        {
            var query = Context.Query<Timesheet>();

            if (request.OwnerId != null)
            {
                query = from timesheet in query
                        where timesheet.OwnerId == request.OwnerId
                        select timesheet;
            }

            if (request.StartDate != null)
            {
                //query = from timesheet in query
                //        from activity in timesheet.Shifts
                //        where request.StartDate <= activity.Reference
                //        select timesheet;
            }

            if (request.EndDate != null)
            {
                //query = from timesheet in query
                //        from activity in timesheet.Shifts
                //        where request.EndDate >= activity.Reference
                //        select timesheet;
            }

            if (request.SearchText != null)
            {
                query = from timesheet in query
                        where timesheet.Name.Contains(request.SearchText)
                        where timesheet.Notes.Contains(request.SearchText)
                        select timesheet;
            }

            var timesheets = from timesheet in query
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