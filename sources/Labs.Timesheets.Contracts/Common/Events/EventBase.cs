using System;

namespace Labs.Timesheets.Contracts.Common.Events
{
    public abstract class EventBase : IEvent
    {
        protected EventBase()
        {
            Stamp = DateTimeOffset.Now;
        }

        public DateTimeOffset Stamp { get; set; }
    }
}