using System;
using Labs.Timesheets.Domain.Common.Commands;

namespace Labs.Timesheets.Domain.Tracking.Commands
{
    public class RemoveActivityCommand : CommandBase
    {
        public Guid ActivityId { get; set; }
    }
}