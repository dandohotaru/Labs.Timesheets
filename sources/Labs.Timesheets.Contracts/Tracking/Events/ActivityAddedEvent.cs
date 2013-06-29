using System;
using System.Collections.Generic;
using Labs.Timesheets.Contracts.Common.Events;
using Labs.Timesheets.Contracts.Common.Values;

namespace Labs.Timesheets.Contracts.Tracking.Events
{
    public class ActivityAddedEvent : EventBase
    {
        public Guid TimesheetId { get; set; }

        public Guid ActivityId { get; set; }

        public List<Guid> ActivityProjectIds { get; set; }

        public DateTime ActivityDate { get; set; }

        public TimeRange ActivityDuration { get; set; }

        public string ActivityDescription { get; set; }
    }
}