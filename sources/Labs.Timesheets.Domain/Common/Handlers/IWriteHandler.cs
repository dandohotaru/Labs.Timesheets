﻿using Labs.Timesheets.Domain.Common.Commands;

namespace Labs.Timesheets.Domain.Common.Handlers
{
    public interface IWriteHandler<in TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}