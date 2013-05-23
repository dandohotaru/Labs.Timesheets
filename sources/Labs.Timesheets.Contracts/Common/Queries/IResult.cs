using System;

namespace Labs.Timesheets.Contracts.Common.Queries
{
    public interface IResult
    {
        DateTimeOffset Stamp { get; }
    }
}