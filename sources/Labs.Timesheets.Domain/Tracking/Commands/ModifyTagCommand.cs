using System;
using Labs.Timesheets.Domain.Common.Commands;

namespace Labs.Timesheets.Domain.Tracking.Commands
{
    public class ModifyTagCommand : CommandBase
    {
        public Guid TagId { get; set; }

        public string TagName { get; set; }

        public string TagNote { get; set; }
    }
}