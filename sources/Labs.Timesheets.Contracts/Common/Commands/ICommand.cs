using System;

namespace Labs.Timesheets.Contracts.Common.Commands
{
    public interface ICommand
    {
        Guid CommandId { get; }

        Guid InitiatorId { get; }

        DateTimeOffset Stamp { get; }
    }
}