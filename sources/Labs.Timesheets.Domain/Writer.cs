using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Commands;
using Labs.Timesheets.Domain.Tracking.Commands;
using Labs.Timesheets.Domain.Tracking.Handlers;

namespace Labs.Timesheets.Domain
{
    public class Writer : IWriter
    {
        public Writer(Func<IStorageAdapter> contextBuilder)
        {
            ContextBuilder = contextBuilder;
        }

        protected Func<IStorageAdapter> ContextBuilder { get; set; }

        public void Execute(ICommand command)
        {
            using (var context = ContextBuilder())
            {
                var instance = (dynamic) this;
                instance.When((dynamic) command, context);
                context.Save();
            }
        }

        public void Execute(IEnumerable<ICommand> commands)
        {
            using (var context = ContextBuilder())
            {
                foreach (var command in commands.Distinct())
                {
                    var instance = (dynamic) this;
                    instance.When((dynamic) command, context);
                }

                context.Save();
            }
        }

        public void When(AddProjectCommand command, IStorageAdapter context)
        {
            new ProjectWriteHandler(context).Handle(command);
        }

        public void When(ModifyProjectCommand command, IStorageAdapter context)
        {
            new ProjectWriteHandler(context).Handle(command);
        }

        public void When(RemovedProjectCommand command, IStorageAdapter context)
        {
            new ProjectWriteHandler(context).Handle(command);
        }
    }
}