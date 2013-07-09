using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Exceptions;
using Labs.Timesheets.Domain.Common.Handlers;
using Labs.Timesheets.Domain.Tracking.Commands;
using Labs.Timesheets.Domain.Tracking.Entities;

namespace Labs.Timesheets.Domain.Tracking.Handlers
{
    public class TagWriteHandler
        : IWriteHandler<AddTagCommand>,
          IWriteHandler<RemoveTagCommand>,
          IWriteHandler<ModifyTagCommand>
    {
        public TagWriteHandler(IStorage context)
        {
            Context = context;
        }

        protected IStorage Context { get; set; }

        public void Handle(AddTagCommand command)
        {
            var tag = Context.Find<Tag>(command.TagId);
            if (tag != null)
                throw new BusinessException("The provided tag {0} already exists in data store.", command.TagId);

            tag = new Tag(command.TagId)
                .ApplyName(command.TagName)
                .ApplyNotes(command.TagNotes);

            Context.Add(tag);
        }

        public void Handle(RemoveTagCommand command)
        {
            var tag = Context.Find<Tag>(command.TagId);
            if (tag == null)
                throw new BusinessException("The provided tag {0} does not exists in data store.", command.TagId);

            Context.Remove(tag);
        }

        public void Handle(ModifyTagCommand command)
        {
            var tag = Context.Find<Tag>(command.TagId);
            if (tag == null)
                throw new BusinessException("The provided tag {0} does not exists in data store.", command.TagId);

            tag.ApplyName(command.TagName)
                .ApplyNotes(command.TagNote);

            Context.Remove(tag);
        }
    }
}