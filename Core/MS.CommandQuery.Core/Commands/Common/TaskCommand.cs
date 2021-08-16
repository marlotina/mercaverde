using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Enums;

namespace MS.CommandQuery.Core.Commands.Common
{
    public class TaskCommand : ICommand
    {
        public int IdTaskProcess { get; set; }

        public EnumTaskProcessType TaskProcessType { get; set; }

        public EnumStatusTask Status { get; set; }
    }
}