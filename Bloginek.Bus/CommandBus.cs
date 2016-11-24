using System;
using System.Diagnostics.Contracts;

namespace Bloginek.Bus
{
    public class CommandBus : ICommandBus
    {
        private readonly Func<Type, ICommandHandler> _handlersFactory;

        public CommandBus(Func<Type, ICommandHandler> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            Contract.Requires(command != null, "Command cannot be null");

            var handler = (ICommandHandler<TCommand>)_handlersFactory(typeof(TCommand));

            Contract.Requires(handler != null, "Missing handler for command of type: " + typeof(TCommand));

            handler.Handle(command);
        }
    }
}
