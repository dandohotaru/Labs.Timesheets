using System;

namespace Labs.Timesheets.Domain.Common
{
    public abstract class Event : IEvent
    {
        protected Event()
        {
            Stamp = DateTimeOffset.Now;
        }

        public DateTimeOffset Stamp { get; set; }
    }
}