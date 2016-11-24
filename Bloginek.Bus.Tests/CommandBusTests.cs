using System;
using FakeItEasy;
using Xunit;

namespace Bloginek.Bus.Tests
{
    public sealed class CommandBusTests
    {
        [Fact]
        public void Null_Handlers_Throw_When_Handling()
        {
            var c = A.Fake<ICommand>();
            var bus = new CommandBus(null);

            Assert.Throws<NullReferenceException>(() => bus.Send(c));
        }

        [Fact]
        public void Command_Is_Send()
        {
            var c = A.Fake<ICommand>();
            var ch = A.Fake<ICommandHandler<ICommand>>();
            
            Func<Type, ICommandHandler> handlers = _ => ch;

            var bus = new CommandBus(handlers);
            bus.Send(c);

            A.CallTo(() => ch.Handle(c)).MustHaveHappened();
        }

        [Fact]
        public void Null_Command_Throws()
        {
            ICommand c = null;
            var bus = new CommandBus(null);

            Assert.Throws<NullReferenceException>(() => bus.Send(c));
        }
    }
}
