using System.Collections.Generic;
using Labs.Timesheets.Domain.Common;

namespace Labs.Timesheets.Domain
{
    public interface ICommander
    {
        void Send(ICommand command);

        void Send(IEnumerable<ICommand> commands);
    }
}