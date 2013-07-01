using System;
using Labs.Timesheets.Reports.Common.Queries;
using Labs.Timesheets.Reports.Tracking.Models;

namespace Labs.Timesheets.Reports.Tracking.Queries
{
    public class FindTimesheetByIdQuery : QueryBase<FindTimesheetByIdResult>
    {
        public Guid TimesheetId { get; set; }
    }

    public class FindTimesheetByIdResult : ResultBase
    {
        public TimesheetDetail Timesheet { get; protected set; }

        public FindTimesheetByIdResult Set(TimesheetDetail detail)
        {
            Timesheet = detail;
            return this;
        }
    }
}