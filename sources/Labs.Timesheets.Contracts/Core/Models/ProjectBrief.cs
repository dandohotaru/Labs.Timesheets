using System;

namespace Labs.Timesheets.Contracts.Core.Models
{
    public class ProjectBrief
    {
        public Guid ProjectId { get; set; }

        public string ProjectName { get; set; }
    }
}