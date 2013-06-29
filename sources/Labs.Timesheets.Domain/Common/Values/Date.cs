using System;

namespace Labs.Timesheets.Domain.Common.Values
{
    public class Date : IValue
    {
        public Date(DateTimeOffset date)
        {
            Year = date.Year;
            Month = date.Month;
            Day = date.Day;
        }

        public int Year { get; protected set; }

        public int Month { get; protected set; }

        public int Day { get; protected set; }

        protected bool Equals(Date other)
        {
            return Year == other.Year
                   && Month == other.Month
                   && Day == other.Day;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (other.GetType() != GetType())
                return false;
            return Equals((Date) other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Year;
                hashCode = (hashCode*397) ^ Month;
                hashCode = (hashCode*397) ^ Day;
                return hashCode;
            }
        }
    }
}