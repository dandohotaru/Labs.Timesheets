using System;
using Labs.Timesheets.Contracts.Common.Commands;

namespace Labs.Timesheets.Contracts.Tracking.Commands
{
    public class RemoveTimesheetCommand : CommandBase
    {
        public Guid TimesheetId { get; set; }
    }
}