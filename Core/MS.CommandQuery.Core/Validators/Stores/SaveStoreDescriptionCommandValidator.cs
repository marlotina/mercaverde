using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Stores;

namespace MS.CommandQuery.Core.Validators.Stores
{
    public class SaveStoreDescriptionCommandValidator : ICommandValidator<SaveStoreDescriptionCommand>
    {
        public ValidationResult Validate(object commandObj)
        {
            var command = (SaveStoreDescriptionCommand)commandObj;

            var result = new ValidationResult() { IsValid = true };
            
            if (string.IsNullOrEmpty(command.Description))
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#TitleEmailObligatorio#");
            }

            if (string.IsNullOrEmpty(command.Title))
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#TextoObligatorio#");
            }

            if (command.StoreId == 0)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#LanguageIdObligatorio#");
            }

            if (command.LanguageId == 0)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#LanguageIdObligatorio#");
            }

            return result;
        }
    }
}
