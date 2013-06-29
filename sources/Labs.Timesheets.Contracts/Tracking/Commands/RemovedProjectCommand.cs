using System;
using Labs.Timesheets.Contracts.Common.Commands;

namespace Labs.Timesheets.Contracts.Tracking.Commands
{
    public class RemovedProjectCommand : CommandBase
    {
        public Guid ProjectId { get; set; }
    }
}