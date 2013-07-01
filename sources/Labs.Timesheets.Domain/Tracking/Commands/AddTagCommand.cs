using System;
using Labs.Timesheets.Domain.Common.Commands;

namespace Labs.Timesheets.Domain.Tracking.Commands
{
    [Serializable]
    public class AddTagCommand : CommandBase<AddTagCommand>
    {
        public Guid TagId { get; set; }

        public string TagName { get; set; }

        public string TagNotes { get; set; }
    }
}