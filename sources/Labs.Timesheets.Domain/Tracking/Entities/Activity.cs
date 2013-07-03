using System;
using System.Collections.Generic;
using System.Text;
using Labs.Timesheets.Domain.Common.Entities;
using Labs.Timesheets.Domain.Common.Exceptions;

namespace Labs.Timesheets.Domain.Tracking.Entities
{
    public class Activity : EntityBase
    {
        public Activity(Guid id) : base(id)
        {
        }

        public DateTimeOffset Start { get; protected set; }

        public DateTimeOffset End { get; protected set; }

        public IList<Tag> Tags { get; protected set; }

        public string Notes { get; protected set; }

        public TimeSpan Duration
        {
            get { return End - Start; }
        }

        public Activity ForTenant(Guid tenantId)
        {
            TenantId = tenantId;
            return this;
        }

        public Activity ApplyPeriod(DateTimeOffset start, DateTimeOffset end)
        {
            if (end <= start)
                throw new BusinessException("The end time needs to be greater than the start time");
            Start = start;
            End = end;
            return this;
        }

        public Activity ApplyPeriod(DateTimeOffset start, TimeSpan duration)
        {
            ApplyPeriod(start, start.Add(duration));
            return this;
        }

        public Activity ApplyNotes(string notes)
        {
            Notes = notes;
            return this;
        }

        public Activity LinkTags(IEnumerable<Tag> tags)
        {
            if (Tags == null)
                Tags = new List<Tag>();

            foreach (var project in tags)
            {
                Tags.Add(project);
            }

            return this;
        }

        public Activity LinkTag(Tag tag)
        {
            return LinkTags(new List<Tag> {tag});
        }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendFormat("Start: {0}. ", Start.ToLocalTime().TimeOfDay)
                .AppendFormat("End: {0}. ", End.ToLocalTime().TimeOfDay)
                .AppendFormat("Duration: {0}. ", Duration.TotalHours)
                .AppendFormat("Notes: {0} ", Notes)
                .ToString();
        }
    }
}