using System.Linq;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Stores;

namespace MS.CommandQuery.Core.Validators.Stores
{
    public class SaveStoreImagesOrderCommandValidator : ICommandValidator<SaveStoreImagesOrderCommand>
    {
        public ValidationResult Validate(object commandObj)
        {
            var command = (SaveStoreImagesOrderCommand)commandObj;

            var result = new ValidationResult() { IsValid = true };
         
            if (command.IdStore == 0)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#NoIdStore#");
            }

            if (!command.Order.Any())
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#NoIdStore#");
            }

            return result;
        }
    }
}
