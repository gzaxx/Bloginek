using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Bloginek.Bus
{
    public class EventBus : IEventBus
    {
        private readonly Func<Type, IEnumerable<IEventHandler>> _handlers;

        public EventBus(Func<Type, IEnumerable<IEventHandler>> handlers)
        {
            _handlers = handlers;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            Contract.Requires(@event != null, "Event cannot be null.");

            var eventHandlers = _handlers(typeof(TEvent))
                .Cast<IEventHandler<TEvent>>();

            foreach (var handler in eventHandlers)
            {
                handler.Handle(@event);
            }
        }
    }
}
