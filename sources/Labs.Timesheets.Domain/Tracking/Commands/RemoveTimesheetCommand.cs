using System;
using Labs.Timesheets.Domain.Common.Commands;

namespace Labs.Timesheets.Domain.Tracking.Commands
{
    public class RemoveTimesheetCommand : CommandBase
    {
        public Guid TimesheetId { get; set; }
    }
}