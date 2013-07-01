using System;
using System.Text;
using Labs.Timesheets.Domain.Common.Values;

namespace Labs.Timesheets.Domain.Tracking.Values
{
    [Serializable]
    public class TimeRange : IValue, IEquatable<TimeRange>
    {
        public TimeRange(TimeSpan start, TimeSpan end)
        {
            Start = start;
            End = end;
        }

        public TimeSpan Start { get; protected set; }

        public TimeSpan End { get; protected set; }

        public TimeSpan Duration
        {
            get { return End - Start; }
        }

        public TimeRange AddHours(double hours)
        {
            var start = End;
            var end = End.Add(TimeSpan.FromHours(hours));
            return new TimeRange(start, end);
        }

        public TimeRange AddMinutes(double minutes)
        {
            var start = End;
            var end = End.Add(TimeSpan.FromMinutes(minutes));
            return new TimeRange(start, end);
        }

        public TimeRange AddSeconds(double seconds)
        {
            var start = End;
            var end = End.Add(TimeSpan.FromSeconds(seconds));
            return new TimeRange(start, end);
        }

        public bool Equals(TimeRange other)
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

        public override string ToString()
        {
            return new StringBuilder()
                .AppendFormat("{0}:{1}", Start.Hours, Start.Minutes)
                .AppendFormat(" - ")
                .AppendFormat("{0}:{1}", End.Hours, End.Minutes)
                .ToString();
        }
    }

    public static class TimeRangeExtensions
    {
        public static double ToHours(this TimeRange instance)
        {
            return (instance.End - instance.Start).TotalHours;
        }

        public static double ToMinutes(this TimeRange instance)
        {
            return (instance.End - instance.Start).TotalMinutes;
        }

        public static double ToSeconds(this TimeRange instance)
        {
            return (instance.End - instance.Start).TotalSeconds;
        }
    }
}