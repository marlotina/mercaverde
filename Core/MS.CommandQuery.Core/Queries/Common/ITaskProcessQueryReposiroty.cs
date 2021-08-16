using System.Collections.Generic;
using MS.CommandQuery.Core.Model;

namespace MS.CommandQuery.Core.Queries.Common
{
    public interface ITaskProcessQueryReposiroty
    {
        List<TaskItem> GetTasksToProcess();
    }
}
