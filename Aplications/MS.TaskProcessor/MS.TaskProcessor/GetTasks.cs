using System;
using System.Collections.Generic;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Common;
using StructureMap;

namespace MS.TaskProcessor
{
    public class GetTasks
    {
        ITaskProcessQueryReposiroty _taskProcessQueryReposiroty { get; set; }

        public GetTasks()
        {
            _taskProcessQueryReposiroty = ObjectFactory.GetInstance<ITaskProcessQueryReposiroty>(); ;
        }

        public List<TaskItem> GetTasksForProcesses()
        {
            var taskList = _taskProcessQueryReposiroty.GetTasksToProcess();
            return taskList;
        }
    }
}