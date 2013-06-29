using Labs.Timesheets.Contracts.Tracking.Commands;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Exceptions;
using Labs.Timesheets.Domain.Common.Handlers;
using Labs.Timesheets.Domain.Tracking.Entities;

namespace Labs.Timesheets.Domain.Tracking.Handlers
{
    public class TimesheetWriteHandler
        : IWriteHandler<AddTimesheetCommand>,
          IWriteHandler<RemoveTimesheetCommand>
    {
        public TimesheetWriteHandler(IStorageAdapter context)
        {
            Context = context;
        }

        protected IStorageAdapter Context { get; set; }

        public void Handle(AddTimesheetCommand command)
        {
            var timesheet = Context.Find<Timesheet>(command.TimesheetId);
            if (timesheet != null)
                throw new BusinessException("The provided timesheet {0} already exists in data store.", command.TimesheetId);

            timesheet = new Timesheet(command.TimesheetId)
                .ApplyName(command.TimesheetName)
                .ApplyNotes(command.TimesheetDescription);

            Context.Add(timesheet);
        }

        public void Handle(RemoveTimesheetCommand command)
        {
            var timesheet = Context.Find<Project>(command.TimesheetId);
            if (timesheet == null)
                throw new BusinessException("The provided timesheet {0} does not exists in data store.", command.TimesheetId);

            Context.Remove(timesheet);
        }
    }
}