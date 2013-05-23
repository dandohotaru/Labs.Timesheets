﻿using System;
using Labs.Timesheets.Domain.Common.Entities;

namespace Labs.Timesheets.Domain.Core.Entities
{
    public class Customer : EntityBase
    {
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

        public Customer ApplyNote(string note)
        {
            Notes = note;
            return this;
        }
    }
}