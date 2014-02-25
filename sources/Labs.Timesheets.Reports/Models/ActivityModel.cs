using System;
using System.Collections.Generic;
using System.Text;
using Labs.Timesheets.Reports.Common;

namespace Labs.Timesheets.Reports.Models
{
    public class ActivityModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public TimeSpan Duration
        {
            get { return End - Start; }
        }

        public List<TagModel> Tags { get; set; }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendFormat("Start: {0}. ", Start.TimeOfDay)
                .AppendFormat("End: {0}. ", End.TimeOfDay)
                .AppendFormat("Duration: {0}. ", Duration.TotalHours)
                .AppendFormat("Name: {0}. ", Name)
                .AppendFormat("Notes: {0} ", Notes)
                .ToString();
        }
    }
}