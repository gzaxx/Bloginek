using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using Xunit;

namespace Bloginek.Bus.Tests
{
    public sealed class QueryBusTests
    {
        [Fact]
        public void Null_Handlers_Throw_When_Handling()
        {
            var q = A.Fake<IQuery<object>>();
            var bus = new QueryBus(null);

            Assert.Throws<NullReferenceException>(() => bus.Process<IQuery<object>, object>(q));
        }

        [Fact]
        public void QueryHandler_Returns_Value_For_Query()
        {
            var q = A.Fake<IQuery<object>>();
            var qh = A.Fake<IQueryHandler<IQuery<object>, object>>();

            A.CallTo(() => qh.Handle(q)).Returns(new object());

            Func<Type, IQueryHandler> handlers = _ => qh;
            var bus = new QueryBus(handlers);

            var result = bus.Process<IQuery<object>, object>(q);

            Assert.NotNull(result);
        }

        [Fact]
        public void Bus_Throws_When_No_Handler_For_Query()
        {
            var q = A.Fake<IQuery<object>>();
            var bus = new QueryBus(null);

            Assert.Throws<NullReferenceException>(() => bus.Process<IQuery<object>, object>(q));
        }

        [Fact]
        public void Handler_Is_Called_For_Query()
        {
            var q1 = A.Fake<IQuery<object>>();
            var qh1 = A.Fake<IQueryHandler<IQuery<object>, object>>();

            Func<Type, IQueryHandler> handlers = _ => qh1;
            var bus = new QueryBus(handlers);

            bus.Process<IQuery<object>, object>(q1);

            A.CallTo(() => qh1.Handle(q1)).MustHaveHappened();
        }

        [Fact]
        public void Handler_Is_Called_For_Query_v2()
        {
            var q1 = A.Fake<IQuery<QueryBusTests>>();
            var qh1 = A.Fake<IQueryHandler<IQuery<QueryBusTests>, QueryBusTests>>();

            var q2 = A.Fake<IQuery<object>>();
            var qh2 = A.Fake<IQueryHandler<IQuery<object>, object>>();

            Dictionary<Type, Bus.IQueryHandler> dict = new Dictionary<Type, IQueryHandler>
            {
                [typeof(IQuery<QueryBusTests>)] = qh1,
                [typeof(IQuery<object>)] = qh2
            };

            Func<Type, IQueryHandler> handlers = t => dict[t];

            var bus = new QueryBus(handlers);

            bus.Process<IQuery<QueryBusTests>, QueryBusTests>(q1);
            bus.Process<IQuery<object>, object>(q2);

            A.CallTo(() => qh1.Handle(q1)).MustHaveHappened();
            A.CallTo(() => qh2.Handle(q2)).MustHaveHappened();
        }
    }
}
