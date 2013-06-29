using System;
using Labs.Timesheets.Domain.Common.Values;

namespace Labs.Timesheets.Reports.Tracking.Models
{
    public class TimesheetBrief
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Hours { get; set; }

        public DateRange Coverage { get; set; }
    }
}