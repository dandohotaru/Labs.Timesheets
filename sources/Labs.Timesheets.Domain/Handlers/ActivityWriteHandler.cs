using System;
using Labs.Timesheets.Domain.Commands;
using Labs.Timesheets.Domain.Common;
using Labs.Timesheets.Domain.Entities;
using Labs.Timesheets.Domain.Exceptions;

namespace Labs.Timesheets.Domain.Handlers
{
    public class ActivityWriteHandler
        : IHandler<AddActivityCommand>,
          IHandler<RemoveActivityCommand>,
          IHandler<ModifyActivityCommand>
    {
        public ActivityWriteHandler(IWriter context)
        {
            Context = context;
        }

        protected IWriter Context { get; set; }

        public void Handle(AddActivityCommand command)
        {
            var activity = Context.Find<Activity>(command.ActivityId);
            if (activity != null)
                throw new BusinessException("The provided activity {0} already exists in data store.", command.ActivityId);

            activity = new Activity(command.ActivityId)
                .ForTenant(command.TenantId)
                .ApplyNotes(command.Notes);

            Context.Add(activity);
        }

        public void Handle(RemoveActivityCommand command)
        {
            var activity = Context.Find<Tag>(command.ActivityId);
            if (activity == null)
                throw new BusinessException("The provided activity {0} does not exists in data store.", command.ActivityId);

            Context.Remove(activity);
        }

        public void Handle(ModifyActivityCommand command)
        {
            throw new NotImplementedException("ToDo");
        }
    }
}