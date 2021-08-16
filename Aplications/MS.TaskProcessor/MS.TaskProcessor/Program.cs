using System;
using log4net;
using log4net.Config;
using MS.CommandQuery.Core.Enums;
using MS.TaskProcessor.Processes;

namespace MS.TaskProcessor
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger("TaskProcessor");
        
        static void Main()
        {
            XmlConfigurator.Configure();
            IoC.InitIoC();

            Log.Info("Start Task Process");
            var task = new GetTasks();
            var listTask = task.GetTasksForProcesses();

            foreach (var taskItem in listTask)
            {
                try
                {
                    switch (taskItem.TaskProcessType)
                    {
                        case (int)EnumTaskProcessType.Register:
                            var activatiProcess = new ActivateUserProcess();
                            activatiProcess.Load(taskItem);
                            break;
                        case (int)EnumTaskProcessType.RecoverPassword:
                            var recoverPasswordProcess = new RecoverPasswordProcess();
                            recoverPasswordProcess.Load(taskItem);
                            break;
                    }
                
                }
                catch (Exception ex)
                {
                    Log.Error("Error:::" + taskItem.UserId + ":::" + ex.Message);
                }
            }


            Log.Info("End Task Process");
        }
    }
}
