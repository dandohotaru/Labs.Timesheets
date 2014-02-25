using System;

namespace Labs.Timesheets.Reports.Common
{
    [Serializable]
    public abstract class Result : IResult
    {
        protected Result()
        {
            Stamp = DateTimeOffset.Now;
        }

        public DateTimeOffset Stamp { get; protected set; }
    }
}