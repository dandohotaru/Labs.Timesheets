using System;

namespace Labs.Timesheets.Reports.Common.Queries
{
    [Serializable]
    public abstract class ResultBase : IResult
    {
        protected ResultBase()
        {
            Stamp = DateTimeOffset.Now;
        }

        public DateTimeOffset Stamp { get; set; }
    }
}