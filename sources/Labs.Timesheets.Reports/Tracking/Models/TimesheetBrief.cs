using System;

namespace Labs.Timesheets.Reports.Tracking.Models
{
    public class TimesheetBrief
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Hours { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }
    }
}