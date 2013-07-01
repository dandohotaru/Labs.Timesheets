using System;
using Labs.Timesheets.Domain.Common.Values;

namespace Labs.Timesheets.Domain.Tracking.Values
{
    [Serializable]
    public class TimeRange : IValue
    {
        public TimeRange(TimeSpan start, TimeSpan end)
        {
            Start = start;
            End = end;
        }

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }

        protected bool Equals(TimeRange other)
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
            return Equals((TimeRange) other);
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