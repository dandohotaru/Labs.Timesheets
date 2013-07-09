using System.Collections.Generic;
using Labs.Timesheets.Domain.Common.Commands;

namespace Labs.Timesheets.Domain
{
    public interface IWriter
    {
        void Send(ICommand command);

        void Send(IEnumerable<ICommand> commands);
    }
}