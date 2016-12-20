namespace Bloginek.Data
{
    public interface IDbWriter
    {
        void Insert(string insertQuery);
        void Update(string updateQuery);
        void Delete(string deleteQuery);
        void InsertOrUpdate(string query);
    }
}
