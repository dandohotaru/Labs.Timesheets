using System;
using System.Collections.Generic;
using Labs.Timesheets.Domain.Common.Entities;
using Labs.Timesheets.Domain.Common.Exceptions;

namespace Labs.Timesheets.Domain.Tracking.Entities
{
    public class Timesheet : EntityBase
    {
        public Timesheet(Guid id)
            : base(id)
        {
        }

        public string Name { get; protected set; }

        public string Notes { get; protected set; }

        public Guid OwnerId { get; protected set; }

        public Guid CustomerId { get; protected set; }

        public List<Shift> Shifts { get; protected set; }

        public Timesheet ApplyName(string name)
        {
            Name = name;
            return this;
        }

        public Timesheet ApplyNotes(string notes)
        {
            Notes = notes;
            return this;
        }

        public Timesheet ApplyOwner(Guid userId)
        {
            OwnerId = userId;
            return this;
        }

        public Timesheet ApplyCustomer(Guid customerId)
        {
            CustomerId = customerId;
            return this;
        }

        public Timesheet AddDays(IEnumerable<Shift> days)
        {
            if (days == null)
                throw new BusinessException("The days to be added can not be null or empty.");

            foreach (var day in days)
            {
                AddDays(day);
            }
            return this;
        }

        public Timesheet AddDays(Shift shift)
        {
            if (shift == null)
                throw new BusinessException("The day to be added can not be null or empty.");
            if (Shifts == null)
                Shifts = new List<Shift>();

            Shifts.Add(shift);
            return this;
        }

        public Timesheet RemoveDays(IEnumerable<Shift> days)
        {
            if (days == null)
                throw new BusinessException("The days to be removed can not be null or empty.");

            foreach (var day in days)
            {
                RemoveDays(day);
            }
            return this;
        }

        public Timesheet RemoveDays(Shift shift)
        {
            if (shift == null)
                throw new BusinessException("The day to be removed can not be null or empty.");
            if (Shifts == null)
                throw new BusinessException("The timesheet {0} has no associated days.", Name);
            if (!Shifts.Contains(shift))
                throw new BusinessException("The timesheet {0} has no day having id {1}.", Name, shift.Id);

            Shifts.Remove(shift);
            return this;
        }
    }
}