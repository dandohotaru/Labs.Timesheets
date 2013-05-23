using System;

namespace Labs.Timesheets.Contracts.Common.Queries
{
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