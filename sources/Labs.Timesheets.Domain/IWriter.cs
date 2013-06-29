using System.Collections.Generic;
using Labs.Timesheets.Domain.Common.Commands;

namespace Labs.Timesheets.Domain
{
    public interface IWriter
    {
        void Execute(ICommand command);

        void Execute(IEnumerable<ICommand> commands);
    }
}