using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Users
{
    public class RecoverPasswordCommand : ICommand
    {
        public string Email { get; set; }
    }
}
