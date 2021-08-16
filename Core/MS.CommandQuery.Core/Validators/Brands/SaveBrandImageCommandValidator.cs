using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Brands;

namespace MS.CommandQuery.Core.Validators.Brands
{
    public class SaveBrandImagesCommandValidator : ICommandValidator<SaveBrandImagesCommand>
    {
        public ValidationResult Validate(object commandObj)
        {
            var command = (SaveBrandImagesCommand)commandObj;

            var result = new ValidationResult() { IsValid = true };
            
            if (string.IsNullOrEmpty(command.ImageUrl))
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#TitleEmailObligatorio#");
            }

            if (command.Order == 0)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#TextoObligatorio#");
            }

            if (command.BrandId == 0)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#LanguageIdObligatorio#");
            }
            return result;
        }
    }
}
