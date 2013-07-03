using System;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Exceptions;
using Labs.Timesheets.Domain.Common.Handlers;
using Labs.Timesheets.Domain.Tracking.Commands;
using Labs.Timesheets.Domain.Tracking.Entities;

namespace Labs.Timesheets.Domain.Tracking.Handlers
{
    public class ActivityWriteHandler
        : IWriteHandler<AddActivityCommand>,
          IWriteHandler<RemoveActivityCommand>,
          IWriteHandler<ModifyActivityCommand>
    {
        public ActivityWriteHandler(IStorageAdapter context)
        {
            Context = context;
        }

        protected IStorageAdapter Context { get; set; }

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