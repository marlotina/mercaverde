using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Stores;

namespace MS.CommandQuery.Core.Validators.Stores
{
    public class SaveStoreImagesCommandValidator : ICommandValidator<SaveStoreImagesCommand>
    {
        public ValidationResult Validate(object commandObj)
        {
            var command = (SaveStoreImagesCommand)commandObj;

            var result = new ValidationResult() { IsValid = true };
            
            if (string.IsNullOrEmpty(command.ImageUrlList))
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#TitleEmailObligatorio#");
            }

            if (command.StoreId == 0)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#LanguageIdObligatorio#");
            }

            return result;
        }
    }
}
