using System;
using System.Collections.Generic;
using Labs.Timesheets.Domain.Common.Entities;
using Labs.Timesheets.Domain.Common.Values;
using Labs.Timesheets.Domain.Tracking.Values;

namespace Labs.Timesheets.Domain.Tracking.Entities
{
    public class Activity : EntityBase
    {
        public Activity(Guid id) : base(id)
        {
        }

        public Guid ShiftId { get; protected set; }

        public DateTimeOffset Date { get; protected set; }

        public string Notes { get; protected set; }

        public TimeRange Period { get; protected set; }

        public IList<Tag> Tags { get; protected set; }

        public Activity ApplyShift(Guid shiftId)
        {
            ShiftId = shiftId;
            return this;
        }

        public Activity ApplyDate(DateTimeOffset date)
        {
            Date = date;
            return this;
        }

        public Activity ApplyPeriod(TimeRange period)
        {
            Period = period;
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
    }
}