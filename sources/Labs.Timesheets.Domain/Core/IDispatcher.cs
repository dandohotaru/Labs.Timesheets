using System.Collections.Generic;
using Labs.Timesheets.Contracts.Common.Commands;
using Labs.Timesheets.Contracts.Common.Queries;

namespace Labs.Timesheets.Domain.Core
{
    public interface IDispatcher
    {
        void Execute(ICommand command);

        void Execute(IEnumerable<ICommand> commands);

        IResult Execute(IQuery query);
    }
}