using System;
using Labs.Timesheets.Domain.Common.Commands;

namespace Labs.Timesheets.Domain.Tracking.Commands
{
    public class RemovedProjectCommand : CommandBase
    {
        public Guid ProjectId { get; set; }
    }
}