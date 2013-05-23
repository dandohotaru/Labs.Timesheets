using System;
using Labs.Timesheets.Contracts.Common.Commands;

namespace Labs.Timesheets.Contracts.Core.Commands
{
    public class ModifyProjectCommand : CommandBase
    {
        public Guid ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ProjectNote { get; set; }
    }
}