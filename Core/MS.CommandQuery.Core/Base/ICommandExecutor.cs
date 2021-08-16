using System.Collections.Generic;

namespace MS.CommandQuery.Core.Base
{
    public interface ICommandExecutor
    {
        void Execute(IEnumerable<ICommand> commands);

        void Execute(ICommand commands);
    }
}