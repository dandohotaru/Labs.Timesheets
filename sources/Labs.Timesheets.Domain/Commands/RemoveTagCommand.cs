using System;
using Labs.Timesheets.Domain.Common;

namespace Labs.Timesheets.Domain.Commands
{
    public class RemoveTagCommand : Command
    {
        public Guid TagId { get; set; }
    }
}