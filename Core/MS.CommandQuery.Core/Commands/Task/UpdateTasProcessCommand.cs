using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Enums;

namespace MS.CommandQuery.Core.Commands.Task
{
    public class UpdateTaskProcessCommand : ICommand
    {
        public int IdTaskProcess { get; set; }

        public EnumStatusTask Status { get; set; }
    }
}
