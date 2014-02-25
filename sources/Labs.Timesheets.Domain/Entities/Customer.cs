using System;
using Labs.Timesheets.Domain.Common;

namespace Labs.Timesheets.Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer()
        {
        }

        public Customer(Guid id)
            : base(id)
        {
        }

        public string Name { get; protected set; }

        public string Notes { get; protected set; }

        public Customer ApplyName(string name)
        {
            Name = name;
            return this;
        }

        public Customer ApplyNotes(string note)
        {
            Notes = note;
            return this;
        }
    }
}