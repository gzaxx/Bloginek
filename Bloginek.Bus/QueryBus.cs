using System;
using System.Diagnostics.Contracts;

namespace Bloginek.Bus
{
    public class QueryBus : IQueryBus
    {
        private readonly Func<Type, IQueryHandler> _handlers;

        public QueryBus(Func<Type, IQueryHandler> handlers)
        {
            _handlers = handlers;
        }

        public TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            Contract.Requires(query != null, "Query cannot be null");

            var handler = (IQueryHandler<TQuery, TResult>)_handlers(typeof(TQuery));

            Contract.Requires(handler != null, "Could not find handler for query of type: " + typeof(TQuery));

            return handler.Handle(query);
        }
    }
}
