using System;
using System.Collections.Generic;
using Labs.Timesheets.Domain.Common.Commands;

namespace Labs.Timesheets.Domain.Tracking.Commands
{
    public class AddActivityCommand : CommandBase
    {
        public Guid TenantId { get; set; }

        public Guid ActivityId { get; set; }

        public Guid ClientId { get; set; }

        public List<Guid> ProjectIds { get; set; }

        public string Description { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }
    }
}