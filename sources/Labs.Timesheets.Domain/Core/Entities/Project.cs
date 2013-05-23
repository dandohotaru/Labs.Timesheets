using System;
using Labs.Timesheets.Domain.Common.Entities;

namespace Labs.Timesheets.Domain.Core.Entities
{
    public class Project : EntityBase
    {
        public Project(Guid id) : base(id)
        {
        }

        public string Name { get; protected set; }

        public string Notes { get; protected set; }

        public Project ApplyName(string name)
        {
            Name = name;
            return this;
        }

        public Project ApplyNote(string note)
        {
            Notes = note;
            return this;
        }
    }
}