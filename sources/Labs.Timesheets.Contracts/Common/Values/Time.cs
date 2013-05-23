using System;

namespace Labs.Timesheets.Contracts.Common.Values
{
    public class Time : IValue
    {
        public Time(DateTimeOffset time)
        {
            Hour = time.Hour;
            Minute = time.Minute;
            Second = time.Second;
            Milisecond = time.Millisecond;
        }

        public int Hour { get; protected set; }

        public int Minute { get; protected set; }

        public int Second { get; protected set; }

        public int Milisecond { get; protected set; }

        protected bool Equals(Time other)
        {
            return Hour == other.Hour
                   && Minute == other.Milisecond
                   && Second == other.Second
                   && Milisecond == other.Milisecond;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (other.GetType() != GetType())
                return false;
            return Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Hour;
                hashCode = (hashCode*397) ^ Minute;
                hashCode = (hashCode*397) ^ Second;
                hashCode = (hashCode*397) ^ Milisecond;
                return hashCode;
            }
        }
    }
}