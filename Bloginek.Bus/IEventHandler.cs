namespace Bloginek.Bus
{
    public interface IEventHandler
    {
    }

    public interface IHandleEvent<TEvent> : IEventHandler
        where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}
