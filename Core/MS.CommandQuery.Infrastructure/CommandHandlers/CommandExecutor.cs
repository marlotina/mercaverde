using System.Collections.Generic;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly IMsContext _context;
        private readonly ICommandDispatcher _dispatcher;

        public CommandExecutor(IMsContext context, ICommandDispatcher dispatcher)
        {
            _context = context;
            _dispatcher = dispatcher;
        }

        public void Execute(IEnumerable<ICommand> commands)
        {
            foreach (var command in commands)
            {
                //var validator = _dispatcher.GetValidator(command);
                //var validationResult = validator.Validate(command);

                //if (!validationResult.IsValid)an
                //    throw new CommandValidationException(validationResult.ErrorMessages);

                var handler = _dispatcher.GetHandler(command);
                handler.Handle(command);
            }

            _context.SaveChanges();
        }

        public void Execute(ICommand command)
        {
            var validator = _dispatcher.GetValidator(command);
            var validationResult = validator.Validate(command);

            if (!validationResult.IsValid)
                throw new CommandValidationException(validationResult.ErrorMessages);

            var handler = _dispatcher.GetHandler(command);
            handler.Handle(command);

            _context.SaveChanges();
        }
    }
}
