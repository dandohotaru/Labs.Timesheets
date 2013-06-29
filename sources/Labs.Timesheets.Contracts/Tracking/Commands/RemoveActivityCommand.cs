using System;
using Labs.Timesheets.Contracts.Common.Commands;

namespace Labs.Timesheets.Contracts.Tracking.Commands
{
    public class RemoveActivityCommand : CommandBase
    {
        public Guid ActivityId { get; set; }
    }
}