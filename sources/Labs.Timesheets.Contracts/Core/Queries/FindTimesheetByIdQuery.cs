using System;
using Labs.Timesheets.Contracts.Common.Queries;
using Labs.Timesheets.Contracts.Core.Models;

namespace Labs.Timesheets.Contracts.Core.Queries
{
    public class FindTimesheetByIdQuery : QueryBase
    {
        public Guid TimesheetId { get; set; }
    }

    public class FindTimesheetByIdResult : ResultBase
    {
        public TimesheetDetail Timesheet { get; set; }
    }
}