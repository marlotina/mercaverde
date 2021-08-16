using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Common;

namespace MS.CommandQuery.Core.Validators.Common
{
    public class SaveStoreCategoriesCommandValidator : ICommandValidator<SaveStoreCategoriesCommand>
    {
        public ValidationResult Validate(object commandObj)
        {
            var command = (SaveStoreCategoriesCommand)commandObj;

            var result = new ValidationResult() { IsValid = true };
            
            if (command.IdStore == 0)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#LanguageIdObligatorio#");
            }

            return result;
        }
    }
}
