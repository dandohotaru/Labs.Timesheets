using System;

namespace Labs.Timesheets.Reports.Common.Queries
{
    public interface IQuery<TResult> : IQuery
        where TResult : IResult
    {
    }

    public interface IQuery
    {
        Guid InitiatorId { get; }

        DateTimeOffset Stamp { get; }
    }
}