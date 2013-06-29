using System;
using Labs.Timesheets.Contracts.Common.Queries;
using Labs.Timesheets.Contracts.Tracking.Models;

namespace Labs.Timesheets.Contracts.Tracking.Queries
{
    public class FindTimesheetByIdQuery : QueryBase<FindTimesheetByIdResult>
    {
        public Guid TimesheetId { get; set; }
    }

    public class FindTimesheetByIdResult : ResultBase
    {
        public TimesheetDetail Timesheet { get; set; }
    }
}