using System;

namespace Labs.Timesheets.Reports.Common.Queries
{
    [Serializable]
    public abstract class QueryBase<TResult> : QueryBase, IQuery<TResult>
        where TResult : IResult
    {
    }

    [Serializable]
    public abstract class QueryBase : IQuery
    {
        protected QueryBase()
        {
            Stamp = DateTimeOffset.Now;
        }

        public Guid InitiatorId { get; set; }

        public DateTimeOffset Stamp { get; private set; }
    }
}