using System.Collections.Generic;
using Labs.Timesheets.Domain.Common.Commands;
using Labs.Timesheets.Domain.Common.Handlers;

namespace Labs.Timesheets.Domain
{
    public interface IWriter
    {
        void Execute(ICommand command);

        void Execute(IEnumerable<ICommand> commands);

        IWriter Register<TCommand, THandler>()
            where TCommand : ICommand
            where THandler : IWriteHandler<TCommand>;
    }
}