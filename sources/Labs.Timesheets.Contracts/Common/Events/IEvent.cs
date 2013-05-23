using System;

namespace Labs.Timesheets.Contracts.Common.Events
{
    public interface IEvent
    {
        DateTimeOffset Stamp { get; }
    }
}