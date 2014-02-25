using System;

namespace Labs.Timesheets.Reports.Common
{
    public interface IQuery<TResult> : IQuery
        where TResult : IResult
    {
    }

    public interface IQuery
    {
        Guid TenantId { get; }

        DateTimeOffset Stamp { get; }
    }
}