using System;
using Labs.Timesheets.Contracts.Common.Commands;

namespace Labs.Timesheets.Contracts.Core.Commands
{
    public class RemoveTimesheetCommand : CommandBase
    {
        public Guid TimesheetId { get; set; }
    }
}