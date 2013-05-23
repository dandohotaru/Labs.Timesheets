using System;
using Labs.Timesheets.Contracts.Common.Commands;

namespace Labs.Timesheets.Contracts.Core.Commands
{
    public class RemoveActivityCommand : CommandBase
    {
        public Guid ActivityId { get; set; }
    }
}