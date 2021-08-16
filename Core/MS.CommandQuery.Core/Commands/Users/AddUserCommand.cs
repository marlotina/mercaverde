using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Users
{
    public class AddUserCommand : ICommand
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool AcceptedConditions { get; set; }

        public int LanguageId { get; set; }
    }
}
