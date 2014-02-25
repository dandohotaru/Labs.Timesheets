using System;
using Labs.Timesheets.Domain.Common;

namespace Labs.Timesheets.Domain.Commands
{
    public class RemoveActivityCommand : Command
    {
        public Guid ActivityId { get; set; }
    }
}