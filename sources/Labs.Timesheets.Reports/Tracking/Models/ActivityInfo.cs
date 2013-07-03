using System;
using System.Collections.Generic;
using System.Text;

namespace Labs.Timesheets.Reports.Tracking.Models
{
    public class ActivityInfo
    {
        public Guid Id { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }

        public TimeSpan Duration
        {
            get { return End - Start; }
        }

        public string Notes { get; set; }

        public List<TagInfo> Tags { get; set; }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendFormat("Start: {0}. ", Start.TimeOfDay)
                .AppendFormat("End: {0}. ", End.TimeOfDay)
                .AppendFormat("Duration: {0}. ", Duration.TotalHours)
                .AppendFormat("Notes: {0}", Notes)
                .ToString();
        }
    }
}