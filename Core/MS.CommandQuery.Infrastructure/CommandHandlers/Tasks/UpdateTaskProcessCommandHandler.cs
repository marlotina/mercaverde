using System;
using System.Linq;
using MS.CommandQuery.Core;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Task;
using MS.CommandQuery.Core.Enums;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Tasks
{
    public class UpdateTaskProcessCommandHandler : ICommandHandler<UpdateTaskProcessCommand>
    {
        private readonly IMsContext _context;

        public UpdateTaskProcessCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            try
            {
                var command = (UpdateTaskProcessCommand)commandObj;

                var taskProcess = _context.ExtranetTaskProcess.FirstOrDefault(t => t.IdTaskProcess == command.IdTaskProcess);
                if (taskProcess != null)
                {
                    taskProcess.UpdateDate = DateTime.Now;
                    if (command.Status == EnumStatusTask.Completed)
                    {
                        taskProcess.Status = (int)EnumStatusTask.Completed;

                    }
                    else
                    {
                        taskProcess.Status = (int)EnumStatusTask.Pending;
                        taskProcess.Attempts = taskProcess.Attempts + 1;
                    }

                    _context.SaveChanges(); 
                }
                
            }
            catch (Exception ex)
            {
                throw new CommandException("AddUserCommandHandler", ex.Message);
            }
        }
    }
}
