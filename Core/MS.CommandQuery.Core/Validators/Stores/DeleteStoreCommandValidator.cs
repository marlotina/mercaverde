using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Stores;

namespace MS.CommandQuery.Core.Validators.Stores
{
    public class DeleteStoreCommandValidator : ICommandValidator<DeleteStoreCommand>
    {
        public ValidationResult Validate(object commandObj)
        {
            var command = (DeleteStoreCommand)commandObj;

            var result = new ValidationResult() { IsValid = true };

            if (command.IdStore > 0)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#NotIdStore#");
            }

            return result;
        }
    }
}
