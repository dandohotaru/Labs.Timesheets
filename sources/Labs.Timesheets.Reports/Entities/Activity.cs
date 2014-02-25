using System;
using System.Collections.Generic;
using System.Text;
using Labs.Timesheets.Reports.Common;

namespace Labs.Timesheets.Reports.Entities
{
    public class Activity : Entity
    {
        public string Name { get; set; }

        public string Notes { get; set; }

        public IList<Tag> Tags { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public TimeSpan Duration
        {
            get { return End - Start; }
        }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendFormat("Start: {0}. ", Start.ToLocalTime().TimeOfDay)
                .AppendFormat("End: {0}. ", End.ToLocalTime().TimeOfDay)
                .AppendFormat("Duration: {0}. ", Duration.TotalHours)
                .AppendFormat("Name: {0}. ", Name)
                .AppendFormat("Notes: {0} ", Notes)
                .ToString();
        }
    }
}