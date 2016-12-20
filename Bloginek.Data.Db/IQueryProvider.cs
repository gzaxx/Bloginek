using System.Collections.Generic;

namespace Bloginek.Data.Db
{
    public interface IQueryProvider
    {
        string Get(string queryName);
        IEnumerable<string> GetAll();
    }
}
