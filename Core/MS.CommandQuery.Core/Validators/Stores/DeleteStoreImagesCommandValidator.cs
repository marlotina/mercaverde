using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Stores;

namespace MS.CommandQuery.Core.Validators.Stores
{
    public class DeleteStoreImagesCommandValidator : ICommandValidator<DeleteStoreImagesCommand>
    {
        public ValidationResult Validate(object commandObj)
        {
            var command = (DeleteStoreImagesCommand)commandObj;

            var result = new ValidationResult() { IsValid = true };
         
            if (command.IdStoreImage == 0)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#NoIdStoreImage#");
            }

            return result;
        }
    }
}
