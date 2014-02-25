using System;
using Labs.Timesheets.Domain.Common;

namespace Labs.Timesheets.Domain.Commands
{
    public class ModifyTagCommand : Command
    {
        public Guid TagId { get; set; }

        public string TagName { get; set; }

        public string TagNote { get; set; }
    }
}