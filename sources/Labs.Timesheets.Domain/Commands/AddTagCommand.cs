using System;
using Labs.Timesheets.Domain.Common;

namespace Labs.Timesheets.Domain.Commands
{
    [Serializable]
    public class AddTagCommand : Command<AddTagCommand>
    {
        public Guid TagId { get; set; }

        public string TagName { get; set; }

        public string TagNotes { get; set; }
    }
}