using System;

namespace Labs.Timesheets.Domain.Common.Events
{
    public interface IEvent
    {
        DateTimeOffset Stamp { get; }
    }
}