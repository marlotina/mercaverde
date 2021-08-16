using System.Collections.Generic;

namespace MS.CommandQuery.Core.Base
{
    public interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        IEnumerable<ValidationResult> Validate(TCommand command);
    }
}
