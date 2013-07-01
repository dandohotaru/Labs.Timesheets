using System;
using Labs.Timesheets.Domain.Common.Entities;

namespace Labs.Timesheets.Domain.Tracking.Entities
{
    public class Tag : EntityBase
    {
        public Tag(Guid id) : base(id)
        {
        }

        public string Name { get; protected set; }

        public string Notes { get; protected set; }

        public Tag ApplyName(string name)
        {
            Name = name;
            return this;
        }

        public Tag ApplyNotes(string notes)
        {
            Notes = notes;
            return this;
        }
    }
}