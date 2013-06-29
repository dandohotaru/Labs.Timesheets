using System;

namespace Labs.Timesheets.Domain.Common.Commands
{
    public interface ICommand
    {
        Guid CommandId { get; }

        Guid InitiatorId { get; }

        DateTimeOffset Stamp { get; }
    }
}