using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Timesheets.Adapters.Resolvers;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Commands;
using Labs.Timesheets.Domain.Common.Handlers;

namespace Labs.Timesheets.Adapters.Dispatchers
{
    public class Writer : IWriter
    {
        public Writer(Func<IStorage> context, IResolver resolver)
        {
            Context = context;
            Resolver = resolver;
        }

        protected Func<IStorage> Context { get; private set; }

        protected IResolver Resolver { get; private set; }

        public void Send(ICommand command)
        {
            using (var context = Context())
            {
                var type = typeof (IWriteHandler<>).MakeGenericType(command.GetType());
                var handler = (dynamic) Resolver.Get(type);
                handler.Handle((dynamic) command);

                context.Save();
            }
        }

        public void Send(IEnumerable<ICommand> commands)
        {
            using (var context = Context())
            {
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
}