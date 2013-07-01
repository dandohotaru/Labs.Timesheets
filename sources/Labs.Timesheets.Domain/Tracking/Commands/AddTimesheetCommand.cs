using System;
using Labs.Timesheets.Domain.Common.Commands;
using Labs.Timesheets.Domain.Common.Values;
using Labs.Timesheets.Domain.Tracking.Values;

namespace Labs.Timesheets.Domain.Tracking.Commands
{
    public class AddTimesheetCommand : CommandBase
    {
        public Guid ClientId { get; set; }

        public Guid TimesheetId { get; set; }

        public string TimesheetName { get; set; }

        public string TimesheetDescription { get; set; }

        public DateRange TimesheetCoverage { get; set; }
    }
}