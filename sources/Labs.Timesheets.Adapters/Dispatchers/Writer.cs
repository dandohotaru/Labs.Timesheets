using System.Collections.Generic;
using System.Linq;
using Labs.Timesheets.Common.Resolvers;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Commands;
using Labs.Timesheets.Domain.Common.Handlers;

namespace Labs.Timesheets.Adapters.Dispatchers
{
    public class Writer : IWriter
    {
        public Writer(IResolver resolver)
        {
            Resolver = resolver;
        }

        protected IResolver Resolver { get; private set; }

        public void Send(ICommand command)
        {
            var context = Resolver.Get<IStorage>();

            var type = typeof (IWriteHandler<>).MakeGenericType(command.GetType());
            var handler = (dynamic) Resolver.Get(type);
            handler.Handle((dynamic) command);

            context.Save();
        }

        public void Send(IEnumerable<ICommand> commands)
        {
            var context = Resolver.Get<IStorage>();

            foreach (var command in commands.Distinct())
            {
                var type = typeof (IWriteHandler<>).MakeGenericType(command.GetType());
                var handler = (dynamic) Resolver.Get(type);
                handler.Handle((dynamic) command);
            }

            context.Save();
        }
    }
}