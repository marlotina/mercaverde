using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Users;

namespace MS.CommandQuery.Core.Validators.Users
{
    public class RecoverPasswordCommandValidator : ICommandValidator<RecoverPasswordCommand>
    {
        public ValidationResult Validate(object commandObj)
        {
            var command = (RecoverPasswordCommand)commandObj;

            var result = new ValidationResult() { IsValid = true };

            if (string.IsNullOrEmpty(command.Email))
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#EmailObligatorio#");
            }

            return result;
        }
    }
}
