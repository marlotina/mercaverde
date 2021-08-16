using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Users;

namespace MS.CommandQuery.Core.Validators.Users
{
    public class AddUserCommandValidator : ICommandValidator<AddUserCommand>
    {
        public ValidationResult Validate(object commandObj)
        {
            var command = (AddUserCommand)commandObj;

            var result = new ValidationResult() { IsValid = true };
            
            if (string.IsNullOrEmpty(command.Email))
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#EmailObligatorio#");
            }

            if (string.IsNullOrEmpty(command.Password))
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#PasswordObligatorio#");
            }

            if (command.AcceptedConditions == false)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#hHay que aceptar las condiciones#");
            }
            return result;
        }
    }
}
