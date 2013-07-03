using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Commands;
using Labs.Timesheets.Domain.Common.Handlers;

namespace Labs.Timesheets.Domain
{
    public class Writer : IWriter
    {
        public Writer(Func<IStorageAdapter> contextBuilder)
        {
            Handlers = new Dictionary<Type, Type>();
            ContextBuilder = contextBuilder;
        }

        protected IDictionary<Type, Type> Handlers { get; set; }

        protected Func<IStorageAdapter> ContextBuilder { get; set; }

        public void Execute(ICommand command)
        {
            // ToDo: Find another approach for resolving dynamic dependencies
            using (var context = ContextBuilder())
            {
                var key = command.GetType();
                if (!Handlers.ContainsKey(key))
                    throw new KeyNotFoundException(key.Name);

                var type = Handlers[key];
                dynamic handler = Activator.CreateInstance(type, context);
                handler.Handle((dynamic) command);
                context.Save();
            }
        }

        public void Execute(IEnumerable<ICommand> commands)
        {
            using (var context = ContextBuilder())
            {
                foreach (var command in commands.Distinct())
                {
                    var key = command.GetType();
                    if (!Handlers.ContainsKey(key))
                        throw new KeyNotFoundException(key.Name);

                    var type = Handlers[key];
                    dynamic handler = Activator.CreateInstance(type, context);
                    handler.Handle((dynamic) command);
                }

                context.Save();
            }
        }

        public IWriter Register<TCommand, THandler>()
            where TCommand : ICommand
            where THandler : IWriteHandler<TCommand>
        {
            // ToDo: Implement caching for resolving handlers
            Handlers.Add(typeof (TCommand), typeof (THandler));
            return this;
        }
    }
}