namespace Labs.Timesheets.Domain.Common
{
    public interface IHandler<in TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}