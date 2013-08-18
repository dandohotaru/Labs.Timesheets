using System;

namespace Labs.Timesheets.Reports.Common.Queries
{
    [Serializable]
    public abstract class QueryBase<TQuery, TResult> : QueryBase<TResult>
        where TQuery : QueryBase<TResult>
        where TResult : IResult
    {
        public TQuery ForTenant(Guid tenantId)
        {
            TenantId = tenantId;
            return this as TQuery;
        }
    }

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

        public Guid TenantId { get; set; }

        public DateTimeOffset Stamp { get; set; }
    }
}