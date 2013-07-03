using System;
using Labs.Timesheets.Domain.Common.Commands;

namespace Labs.Timesheets.Domain.Tracking.Commands
{
    public class RemoveTagCommand : CommandBase
    {
        public Guid TagId { get; set; }
    }
}