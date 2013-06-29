using System;

namespace Labs.Timesheets.Reports.Common.Queries
{
    public interface IResult
    {
        DateTimeOffset Stamp { get; }
    }
}