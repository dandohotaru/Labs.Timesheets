using System;
using Labs.Timesheets.Domain.Common.Commands;

namespace Labs.Timesheets.Domain.Tracking.Commands
{
    [Serializable]
    public class AddProjectCommand : CommandBase<AddProjectCommand>
    {
        public Guid ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ProjectNote { get; set; }
    }
}