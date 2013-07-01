using System;
using Labs.Timesheets.Domain.Common.Values;

namespace Labs.Timesheets.Domain.Tracking.Values
{
    [Serializable]
    public class DateRange : IValue
    {
        public DateRange(DateTimeOffset start, DateTimeOffset end)
        {
            Start = start;
            End = end;
        }

        public DateTimeOffset Start { get; protected set; }

        public DateTimeOffset End { get; protected set; }

        protected bool Equals(DateRange other)
        {
            return Start.Equals(other.Start)
                   && End.Equals(other.End);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (other.GetType() != GetType())
                return false;
            return Equals((DateRange) other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Start.GetHashCode()*397) ^ End.GetHashCode();
            }
        }
    }
}