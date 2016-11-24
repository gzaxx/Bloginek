namespace Bloginek.Bus
{
    public interface IEventHandler
    {
    }

    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}
