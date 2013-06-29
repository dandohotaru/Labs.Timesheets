using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Exceptions;
using Labs.Timesheets.Domain.Common.Handlers;
using Labs.Timesheets.Domain.Tracking.Commands;
using Labs.Timesheets.Domain.Tracking.Entities;

namespace Labs.Timesheets.Domain.Tracking.Handlers
{
    public class ProjectWriteHandler
        : IWriteHandler<AddProjectCommand>,
          IWriteHandler<RemovedProjectCommand>,
          IWriteHandler<ModifyProjectCommand>
    {
        public ProjectWriteHandler(IStorageAdapter context)
        {
            Context = context;
        }

        protected IStorageAdapter Context { get; set; }

        public void Handle(AddProjectCommand command)
        {
            var project = Context.Find<Project>(command.ProjectId);
            if (project != null)
                throw new BusinessException("The provided project {0} already exists in data store.", command.ProjectId);

            project = new Project(command.ProjectId)
                .ChangeName(command.ProjectName)
                .ChangeNote(command.ProjectNote);

            Context.Add(project);
        }

        public void Handle(RemovedProjectCommand command)
        {
            var project = Context.Find<Project>(command.ProjectId);
            if (project == null)
                throw new BusinessException("The provided project {0} does not exists in data store.", command.ProjectId);

            Context.Remove(project);
        }

        public void Handle(ModifyProjectCommand command)
        {
            var project = Context.Find<Project>(command.ProjectId);
            if (project == null)
                throw new BusinessException("The provided project {0} does not exists in data store.", command.ProjectId);

            project
                .ChangeName(command.ProjectName)
                .ChangeNote(command.ProjectNote);

            Context.Remove(project);
        }
    }
}