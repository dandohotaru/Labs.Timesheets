using System;

namespace Labs.Timesheets.Contracts.Tracking.Models
{
    public class ProjectDetail
    {
        public Guid ProjectId { get; set; }

        public string ProjectName { get; set; }
    }
}