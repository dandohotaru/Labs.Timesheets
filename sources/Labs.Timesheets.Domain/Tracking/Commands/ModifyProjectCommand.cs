using System;
using Labs.Timesheets.Domain.Common.Commands;

namespace Labs.Timesheets.Domain.Tracking.Commands
{
    public class ModifyProjectCommand : CommandBase
    {
        public Guid ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ProjectNote { get; set; }
    }
}