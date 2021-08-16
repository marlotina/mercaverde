using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Stores;

namespace MS.CommandQuery.Core.Validators.Stores
{
    public class SaveStoreCommandValidator : ICommandValidator<SaveStoreCommand>
    {
        public ValidationResult Validate(object commandObj)
        {
            var command = (SaveStoreCommand)commandObj;

            var result = new ValidationResult() { IsValid = true };
            
            //if (string.IsNullOrEmpty(command.Email))
            //{
            //    result.IsValid = false;
            //    result.ErrorMessages.Add("#TitleEmailObligatorio#");
            //}

            //if (string.IsNullOrEmpty(command.Name))
            //{
            //    result.IsValid = false;
            //    result.ErrorMessages.Add("#TitleEmailObligatorio#");
            //}

            //if (string.IsNullOrEmpty(command.Street))
            //{
            //    result.IsValid = false;
            //    result.ErrorMessages.Add("#TextoObligatorio#");
            //}

            //if (command.UserId == 0)
            //{
            //    result.IsValid = false;
            //    result.ErrorMessages.Add("#LanguageIdObligatorio#");
            //}

            return result;
        }
    }
}
