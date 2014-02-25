using System;

namespace Labs.Timesheets.Domain.Common
{
    public interface ICommand
    {
        Guid CommandId { get; }

        Guid InitiatorId { get; }

        DateTimeOffset Stamp { get; }
    }
}