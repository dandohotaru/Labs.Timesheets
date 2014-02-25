using System;

namespace Labs.Timesheets.Domain.Common
{
    public interface IEvent
    {
        DateTimeOffset Stamp { get; }
    }
}