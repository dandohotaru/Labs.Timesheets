using System;
using Labs.Timesheets.Domain.Common.Entities;

namespace Labs.Timesheets.Domain.Core.Entities
{
    public class Tag : EntityBase
    {
        public Tag(Guid id) : base(id)
        {
        }

        public Tag(Guid id, string name)
            : base(id)
        {
            Name = name;
        }

        public string Name { get; protected set; }

        public Tag ApplyName(string name)
        {
            Name = name;
            return this;
        }
    }
}