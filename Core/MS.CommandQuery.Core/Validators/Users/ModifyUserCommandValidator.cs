using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Users;

namespace MS.CommandQuery.Core.Validators.Users
{
    public class ModifyUserCommandValidator : ICommandValidator<SaveUserCommand>
    {
        public ValidationResult Validate(object commandObj)
        {
            var command = (SaveUserCommand)commandObj;

            var result = new ValidationResult() { IsValid = true };

            //if (command.StrictValidate)
            //{
            //    if (string.IsNullOrEmpty(command.Email))
            //    {
            //        result.IsValid = false;
            //        result.ErrorMessages.Add("#EmailObligatorio#");
            //    }

            //    if (string.IsNullOrEmpty(command.Password))
            //    {
            //        result.IsValid = false;
            //        result.ErrorMessages.Add("#PasswordObligatorio#");
            //    }
            //}

            return result;
        }
    }
}