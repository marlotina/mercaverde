using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Brands;

namespace MS.CommandQuery.Core.Validators.Brands
{
    public class SaveBrandCommandValidator : ICommandValidator<SaveBrandCommand>
    {
        public ValidationResult Validate(object commandObj)
        {
            var command = (SaveBrandCommand)commandObj;

            var result = new ValidationResult() { IsValid = true };
            
            if (string.IsNullOrEmpty(command.PostalCode))
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#TitleEmailObligatorio#");
            }

            if (string.IsNullOrEmpty(command.Street))
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#TextoObligatorio#");
            }

            if (command.UserId == 0)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#LanguageIdObligatorio#");
            }

            return result;
        }
    }
}
