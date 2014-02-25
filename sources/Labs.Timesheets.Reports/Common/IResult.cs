using System;

namespace Labs.Timesheets.Reports.Common
{
    public interface IResult
    {
        DateTimeOffset Stamp { get; }
    }
}