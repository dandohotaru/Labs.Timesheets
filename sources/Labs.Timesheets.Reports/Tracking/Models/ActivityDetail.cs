using System;
using System.Collections.Generic;

namespace Labs.Timesheets.Reports.Tracking.Models
{
    public class ActivityDetail
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }

        public List<ProjectBrief> Projects { get; set; }
    }
}