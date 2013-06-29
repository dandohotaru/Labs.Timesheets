using System;
using System.Collections.Generic;
using Labs.Timesheets.Contracts.Common.Values;

namespace Labs.Timesheets.Contracts.Tracking.Models
{
    public class TimesheetDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Hours { get; set; }

        public DateRange Coverage { get; set; }

        public List<ActivityDetail> Activities { get; set; }
    }
}