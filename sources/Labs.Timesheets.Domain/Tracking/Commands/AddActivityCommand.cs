﻿using System;
using System.Collections.Generic;
using Labs.Timesheets.Domain.Common.Commands;

namespace Labs.Timesheets.Domain.Tracking.Commands
{
    public class AddActivityCommand : CommandBase
    {
        public Guid TenantId { get; set; }

        public Guid ClientId { get; set; }
        
        public Guid ActivityId { get; set; }

        public List<Guid> TagIds { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }

        public string Notes { get; set; }
    }
}