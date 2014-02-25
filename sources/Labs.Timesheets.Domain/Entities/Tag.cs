using System;
using Labs.Timesheets.Domain.Common;

namespace Labs.Timesheets.Domain.Entities
{
    public class Tag : Entity
    {
        protected Tag()
        {
        }

        public Tag(Guid id) 
            : base(id)
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