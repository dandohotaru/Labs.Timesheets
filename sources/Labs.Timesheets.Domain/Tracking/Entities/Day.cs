using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Timesheets.Contracts.Common.Values;
using Labs.Timesheets.Domain.Common.Entities;
using Labs.Timesheets.Domain.Common.Exceptions;

namespace Labs.Timesheets.Domain.Tracking.Entities
{
    public class Day : EntityBase
    {
        public Day(Guid id)
            : base(id)
        {
        }

        public Guid TimesheetId { get; protected set; }

        public DateTimeOffset Reference { get; protected set; }

        public List<Activity> Activities { get; protected set; }

        public Day ApplyTimesheet(Guid timesheetId)
        {
            TimesheetId = timesheetId;
            return this;
        }

        public Day ApplyDate(DateTimeOffset date)
        {
            Reference = date;
            return this;
        }

        public Day AddActivity(Activity activity)
        {
            if (activity == null)
                throw new BusinessException("The activity to be added can not be null nor empty.");

            if (Activities == null)
                Activities = new List<Activity>();
            Activities.Add(activity);
            return this;
        }

        public Day RemoveActivity(Activity activity)
        {
            if (activity == null)
                throw new BusinessException("The day to be removed can not be null nor empty.");
            if (Activities == null)
                throw new BusinessException("The day {0} has no activities.", Reference.Date.ToShortDateString());
            if (!Activities.Contains(activity))
                throw new BusinessException("The day {0} has no activity having id {1}.",
                                            Reference.Date.ToShortDateString(), activity.Id);

            Activities.Remove(activity);
            return this;
        }

        public Day MoveActivity(Activity activity, TimeSpan begin)
        {
            var duration = activity.Period.To.Subtract(activity.Period.From);
            var others = from other in Activities
                         where (other.Period.From <= begin && begin <= other.Period.To)
                               || (other.Period.From >= begin)
                         select other;
            foreach (var other in others)
            {
                var from = other.Period.From.Add(duration);
                var to = other.Period.To.Add(duration);
                other.ApplyPeriod(new TimeRange(from, to));
            }

            var end = activity.Period.To.Add(duration);
            activity.ApplyPeriod(new TimeRange(begin, end));

            return this;
        }

        public Day MoveActivity(Activity activity, Guid dayId)
        {
            RemoveActivity(activity);
            activity.ApplyDay(dayId);
            return this;
        }
    }
}