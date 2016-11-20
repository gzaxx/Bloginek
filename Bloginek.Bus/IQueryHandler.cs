﻿namespace Bloginek.Bus
{
    public interface IQueryHandler
    { }

    public interface IQueryHandler<in TQuery, out TResult> : IQueryHandler
        where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
