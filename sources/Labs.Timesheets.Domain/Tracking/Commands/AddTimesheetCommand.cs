using System;
using Labs.Timesheets.Domain.Common.Commands;

namespace Labs.Timesheets.Domain.Tracking.Commands
{
    public class AddTimesheetCommand : CommandBase
    {
        public Guid ClientId { get; set; }

        public Guid TimesheetId { get; set; }

        public string TimesheetName { get; set; }

        public string TimesheetDescription { get; set; }
    }
}