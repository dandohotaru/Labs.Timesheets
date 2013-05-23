using System;
using Labs.Timesheets.Contracts.Common.Values;

namespace Labs.Timesheets.Contracts.Core.Models
{
    public class TimesheetBrief
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Hours { get; set; }

        public DateRange Coverage { get; set; }
    }
}