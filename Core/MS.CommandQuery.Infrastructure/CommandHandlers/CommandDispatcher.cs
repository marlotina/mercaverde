using System;
using MS.CommandQuery.Core.Base;
using StructureMap;

namespace MS.CommandQuery.Infrastructure.CommandHandlers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        public ICommandHandler GetHandler(ICommand command)
        {
            var commandType = command.GetType();

            Type handlerType = typeof(ICommandHandler<>);
            Type constructedClass = handlerType.MakeGenericType(commandType);

            var handler = ObjectFactory.GetInstance(constructedClass);

            return handler as ICommandHandler;
        }

        public ICommandValidator GetValidator(ICommand command)
        {
            var commandType = command.GetType();

            Type validatorType = typeof(ICommandValidator<>);
            Type constructedClass = validatorType.MakeGenericType(commandType);

            var validator = ObjectFactory.GetInstance(constructedClass);

            return validator as ICommandValidator;
        }
    }
}