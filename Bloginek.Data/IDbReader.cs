using System.Collections.Generic;

namespace Bloginek.Data
{
    public interface IDbReader
    {
        T Get<T>(string query);
        IEnumerable<T> GetAll<T>(string query);
    }
}
