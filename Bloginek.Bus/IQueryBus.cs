namespace Bloginek.Bus
{
    public interface IQueryBus
    {
        TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
