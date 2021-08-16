namespace MS.CommandQuery.Core.Base
{
    public interface ICommandValidator
    {
        ValidationResult Validate(object commandObj);
    }

    public interface ICommandValidator<TCommand> : ICommandValidator where TCommand : ICommand
    {
    }
}
