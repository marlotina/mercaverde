namespace MS.CommandQuery.Core.Base
{
    public interface ICommandDispatcher
    {
        ICommandHandler GetHandler(ICommand command);

        ICommandValidator GetValidator(ICommand command);
    }
}
