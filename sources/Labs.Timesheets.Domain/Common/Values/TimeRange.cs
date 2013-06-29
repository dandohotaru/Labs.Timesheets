using System;

namespace Labs.Timesheets.Domain.Common.Values
{
    [Serializable]
    public class TimeRange : IValue
    {
        public TimeRange(TimeSpan from, TimeSpan to)
        {
            From = from;
            To = to;
        }

        public TimeSpan From { get; set; }

        public TimeSpan To { get; set; }

        protected bool Equals(TimeRange other)
        {
            return From.Equals(other.From)
                   && To.Equals(other.To);
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
                return (From.GetHashCode()*397) ^ To.GetHashCode();
            }
        }
    }
}