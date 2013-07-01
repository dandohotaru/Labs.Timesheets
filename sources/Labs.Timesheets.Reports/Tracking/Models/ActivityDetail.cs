using System;
using System.Collections.Generic;
using System.Text;

namespace Labs.Timesheets.Reports.Tracking.Models
{
    public class ActivityDetail
    {
        public Guid Id { get; set; }

        public DateTimeOffset Date { get; set; }

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }

        public string Notes { get; set; }

        public List<TagBrief> Tags { get; set; }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendFormat("Date: {0}. ", Date.DateTime.ToShortDateString())
                .AppendFormat("Start: {0}. ", Start)
                .AppendFormat("End: {0}. ", End)
                .AppendFormat("Notes: {0}", Notes)
                .ToString();
        }
    }
}