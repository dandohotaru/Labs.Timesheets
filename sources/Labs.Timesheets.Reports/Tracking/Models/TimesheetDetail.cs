using System;
using System.Collections.Generic;

namespace Labs.Timesheets.Reports.Tracking.Models
{
    public class TimesheetDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Hours { get; set; }

        public List<ActivityDetail> Activities { get; set; }
    }
}