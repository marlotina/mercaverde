using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Posts;

namespace MS.CommandQuery.Core.Validators.Posts
{
    public class SavePostCommandValidator : ICommandValidator<SavePostCommand>
    {
        public ValidationResult Validate(object commandObj)
        {
            var command = (SavePostCommand)commandObj;

            var result = new ValidationResult() { IsValid = true };
            
            if (string.IsNullOrEmpty(command.Title))
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#TitleEmailObligatorio#");
            }

            if (string.IsNullOrEmpty(command.Text))
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#TextoObligatorio#");
            }

            if (command.LanguageId == 0)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#LanguageIdObligatorio#");
            }

            if (command.UserId == 0)
            {
                result.IsValid = false;
                result.ErrorMessages.Add("#UserIdObligatorio#");
            }

            return result;
        }
    }
}
