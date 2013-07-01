using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Timesheets.Domain.Common.Entities;
using Labs.Timesheets.Domain.Common.Exceptions;
using Labs.Timesheets.Domain.Common.Values;
using Labs.Timesheets.Domain.Tracking.Values;

namespace Labs.Timesheets.Domain.Tracking.Entities
{
    public class Shift : EntityBase
    {
        public Shift(Guid id)
            : base(id)
        {
        }

        public List<Activity> Activities { get; protected set; }

        public Shift AddActivity(Activity activity)
        {
            if (activity == null)
                throw new BusinessException("The activity to be added can not be null nor empty.");

            if (Activities == null)
                Activities = new List<Activity>();
            Activities.Add(activity);
            return this;
        }

        public Shift RemoveActivity(Activity activity)
        {
            if (activity == null)
                throw new BusinessException("The activity can not be null nor empty.");
            if (Activities == null)
                throw new BusinessException("The activity could not be found.");
            if (!Activities.Contains(activity))
                throw new BusinessException("The activity could not be found.");

            Activities.Remove(activity);
            return this;
        }

        public Shift MoveActivity(Activity activity, TimeSpan begin)
        {
            var duration = activity.Period.End.Subtract(activity.Period.Start);
            var others = from other in Activities
                         where (other.Period.Start <= begin && begin <= other.Period.End)
                               || (other.Period.Start >= begin)
                         select other;
            foreach (var other in others)
            {
                var from = other.Period.Start.Add(duration);
                var to = other.Period.End.Add(duration);
                other.ApplyPeriod(new TimeRange(from, to));
            }

            var end = activity.Period.End.Add(duration);
            activity.ApplyPeriod(new TimeRange(begin, end));

            return this;
        }

        public Shift MoveActivity(Activity activity, Guid dayId)
        {
            RemoveActivity(activity);
            activity.ApplyShift(dayId);
            return this;
        }
    }
}