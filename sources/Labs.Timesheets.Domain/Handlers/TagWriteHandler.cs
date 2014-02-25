using Labs.Timesheets.Domain.Commands;
using Labs.Timesheets.Domain.Common;
using Labs.Timesheets.Domain.Entities;
using Labs.Timesheets.Domain.Exceptions;

namespace Labs.Timesheets.Domain.Handlers
{
    public class TagWriteHandler
        : IHandler<AddTagCommand>,
          IHandler<RemoveTagCommand>,
          IHandler<ModifyTagCommand>
    {
        public TagWriteHandler(IWriter context)
        {
            Context = context;
        }

        protected IWriter Context { get; set; }

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