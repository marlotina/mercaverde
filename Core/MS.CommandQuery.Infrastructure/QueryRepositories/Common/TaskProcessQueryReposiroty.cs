using System.Collections.Generic;
using System.Linq;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Common;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Common
{
    public class TaskProcessQueryReposiroty : QueryBase, ITaskProcessQueryReposiroty
    {
        public TaskProcessQueryReposiroty(IMsContext context)
            : base(context)
        {
        }

        public List<TaskItem> GetTasksToProcess()
        {
            const string query = "spGetTasksToProcess";

            var taskList = Context.Database.SqlQuery<TaskItem>(query);

            return taskList.ToList();
        }
    }
}