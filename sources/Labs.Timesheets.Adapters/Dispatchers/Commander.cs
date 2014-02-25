using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Timesheets.Domain;
using Labs.Timesheets.Domain.Common;
using Ninject;
using Ninject.Parameters;

namespace Labs.Timesheets.Adapters.Dispatchers
{
    public class Commander : ICommander
    {
        public Commander(Func<IWriter> context, IKernel resolver)
        {
            Context = context;
            Resolver = resolver;
        }

        protected Func<IWriter> Context { get; private set; }

        protected IKernel Resolver { get; private set; }

        public void Send(ICommand command)
        {
            using (var context = Context())
            {
                var contextParameter = new ConstructorArgument("context", context);
                var handlerType = typeof (IHandler<>).MakeGenericType(command.GetType());
                var handler = (dynamic) Resolver.Get(handlerType, contextParameter);
                handler.Handle((dynamic) command);

                context.Save();
            }
        }

        public void Send(IEnumerable<ICommand> commands)
        {
            using (var context = Context())
            {
                var contextParameter = new ConstructorArgument("context", context);
                foreach (var command in commands.Distinct())
                {
                    var handlerType = typeof (IHandler<>).MakeGenericType(command.GetType());
                    var handler = (dynamic) Resolver.Get(handlerType, contextParameter);
                    handler.Handle((dynamic) command);
                }

                context.Save();
            }
        }
    }
}