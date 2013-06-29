using System;

namespace Labs.Timesheets.Domain.Common.Commands
{
    [Serializable]
    public abstract class CommandBase<TCommand> : CommandBase
        where TCommand : ICommand
    {
        protected bool Equals(TCommand other)
        {
            return CommandId.Equals(other.CommandId);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (other.GetType() != GetType())
                return false;
            return Equals((TCommand) other);
        }

        public override int GetHashCode()
        {
            return CommandId.GetHashCode();
        }
    }

    [Serializable]
    public abstract class CommandBase : ICommand
    {
        protected CommandBase()
        {
            CommandId = Guid.NewGuid();
            Stamp = DateTimeOffset.Now;
        }

        public Guid CommandId { get; private set; }

        public Guid InitiatorId { get; set; }

        public DateTimeOffset Stamp { get; private set; }
    }
}