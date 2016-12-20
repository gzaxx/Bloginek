using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bloginek.Data.Db
{
    public class QueryProvider : IQueryProvider
    {
        private const string QUERY_FOLDER = "Sql";
        private const string QUERY_EXTENSION = ".sql";

        private readonly string _queryPath;

        public QueryProvider()
        {
            _queryPath = Directory.GetCurrentDirectory();
        }

        public string Get(string queryName)
        {
            string path = GetPath(queryName);

            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }

            throw new FileNotFoundException(path);
        }

        public IEnumerable<string> GetAll()
        {
            return Directory.GetFiles(GetPath())
                .Where(x => x.EndsWith(QUERY_EXTENSION))
                .Select(x => File.ReadAllText(x));
        }

        private string GetPath()
        {
            return Path.Combine(_queryPath, QUERY_FOLDER);
        }

        private string GetPath(string queryName)
        {
            return Path.Combine(_queryPath, QUERY_FOLDER, queryName) + QUERY_EXTENSION;
        }
    }
}
