using System;
using Labs.Timesheets.Contracts.Common.Commands;
using Labs.Timesheets.Contracts.Common.Values;

namespace Labs.Timesheets.Contracts.Tracking.Commands
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