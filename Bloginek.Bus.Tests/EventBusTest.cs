using System;
using System.Collections.Generic;
using FakeItEasy;
using Xunit;

namespace Bloginek.Bus.Tests
{
    public sealed class EventBusTest
    {
        [Fact]
        public void Null_Handlers_Throws_When_Publishing()
        {
            var e = A.Fake<IEvent>();
            var bus = new EventBus(null);
            Assert.Throws<NullReferenceException>(() => bus.Publish(e));
        }

        [Fact]
        public void Event_Published()
        {
            var e = A.Fake<IEvent>();
            var ev = A.Fake<IEventHandler<IEvent>>();

            var handlers = new List<IEventHandler<IEvent>> { ev };

            Func<Type, IEnumerable<IEventHandler>> resolvers = _ => handlers;
            var bus = new EventBus(resolvers);
            bus.Publish(e);

            A.CallTo(() => ev.Handle(e)).MustHaveHappened();
        }

        [Fact]
        public void Event_Published_To_Different_Handlers()
        {
            var e = A.Fake<IEvent>();
            var ev1 = A.Fake<IEventHandler<IEvent>>();
            var ev2 = A.Fake<IEventHandler<IEvent>>();

            var handlers = new List<IEventHandler<IEvent>> { ev1, ev2 };

            Func<Type, IEnumerable<IEventHandler>> resolvers = _ => handlers;
            var bus = new EventBus(resolvers);
            bus.Publish(e);

            A.CallTo(() => ev1.Handle(e)).MustHaveHappened();
            A.CallTo(() => ev2.Handle(e)).MustHaveHappened();
        }

        [Fact]
        public void Null_Event_Throws()
        {
            IEvent e = null;
            var bus = new EventBus(null);

            Assert.Throws<NullReferenceException>(() => bus.Publish(e));
        }
    }
}
