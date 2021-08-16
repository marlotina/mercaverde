using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Brands;

namespace MS.CommandQuery.Core.Validators.Brands
{
    public class SaveBrandDescriptionCommandValidator : ICommandValidator<SaveBrandDescriptionCommand>
    {
        public ValidationResult Validate(object commandObj)
        {
            var command = (SaveBrandDescriptionCommand)commandObj;

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

            if (command.BrandId == 0)
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
