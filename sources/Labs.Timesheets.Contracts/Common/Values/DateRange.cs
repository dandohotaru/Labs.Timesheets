using System;

namespace Labs.Timesheets.Contracts.Common.Values
{
    [Serializable]
    public class DateRange : IValue
    {
        public DateRange(DateTimeOffset from, DateTimeOffset to)
        {
            From = from;
            To = to;
        }

        public DateTimeOffset From { get; protected set; }

        public DateTimeOffset To { get; protected set; }

        protected bool Equals(DateRange other)
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
            return Equals((DateRange) other);
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