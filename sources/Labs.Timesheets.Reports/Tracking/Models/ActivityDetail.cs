using System;
using System.Collections.Generic;
using Labs.Timesheets.Domain.Common.Values;

namespace Labs.Timesheets.Reports.Tracking.Models
{
    public class ActivityDetail
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public TimeRange Duration { get; set; }

        public List<ProjectBrief> Projects { get; set; }
    }
}