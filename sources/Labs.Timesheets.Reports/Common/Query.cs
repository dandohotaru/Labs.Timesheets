using System;

namespace Labs.Timesheets.Reports.Common
{
    [Serializable]
    public abstract class Query<TQuery, TResult> : Query<TResult>
        where TQuery : Query<TResult>
        where TResult : IResult
    {
        public TQuery ForTenant(Guid tenantId)
        {
            TenantId = tenantId;
            return this as TQuery;
        }
    }

    [Serializable]
    public abstract class Query<TResult> : Query, IQuery<TResult>
        where TResult : IResult
    {
    }

    [Serializable]
    public abstract class Query : IQuery
    {
        protected Query()
        {
            Stamp = DateTimeOffset.Now;
        }

        public Guid TenantId { get; set; }

        public DateTimeOffset Stamp { get; set; }
    }
}