using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Timesheets.Contracts.Common.Commands;
using Labs.Timesheets.Contracts.Common.Queries;
using Labs.Timesheets.Contracts.Core.Commands;
using Labs.Timesheets.Contracts.Core.Queries;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Core.Handlers;

namespace Labs.Timesheets.Domain.Core
{
    public class Dispatcher : IDispatcher
    {
        public Dispatcher(Func<IStorageAdapter> contextBuilder)
        {
            ContextBuilder = contextBuilder;
        }

        protected Func<IStorageAdapter> ContextBuilder { get; set; }

        public void Execute(ICommand command)
        {
            using (var context = ContextBuilder())
            {
                var instance = (dynamic)this;
                instance.When((dynamic)command, context);
                context.Save();
            }
        }

        public void Execute(IEnumerable<ICommand> commands)
        {
            using (var context = ContextBuilder())
            {
                foreach (var command in commands.Distinct())
                {
                    var instance = (dynamic)this;
                    instance.When((dynamic)command, context);
                }

                context.Save();
            }
        }

        public IResult Execute(IQuery query)
        {
            using (var context = ContextBuilder())
            {
                var instance = (dynamic)this;
                return instance.When((dynamic)query, context) as IResult;
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

        public FindProjectsByIdsResult When(FindProjectsByIdsQuery query, IStorageAdapter context)
        {
            return new ProjectReadHandler(context).Handle(query);
        }

        public FindProjectsByTextResult When(FindProjectsByTextQuery query, IStorageAdapter context)
        {
            return new ProjectReadHandler(context).Handle(query);
        }
    }
}
