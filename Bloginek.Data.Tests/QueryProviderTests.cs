using Bloginek.Data.Db;
using System.IO;
using Xunit;

namespace Bloginek.Data.Tests
{
    public sealed class QueryProviderTests
    {
        public const string INVALID_QUERY = "invalid";
        public const string VALID_QUERY = "create_redirects_table";

        private readonly Db.IQueryProvider _queryProvider;

        public QueryProviderTests()
        {
            _queryProvider = new QueryProvider();
        }

        [Fact]
        public void Fails_If_No_Exists()
        {
            Assert.Throws<FileNotFoundException>(() => _queryProvider.Get(INVALID_QUERY));
        }

        [Fact]
        public void Returns_Valid_Query()
        {
            string query = _queryProvider.Get(VALID_QUERY);

            Assert.NotNull(query);
        }

        [Fact]
        public void Returns_Queries()
        {
            var queries = _queryProvider.GetAll();

            Assert.NotNull(queries);
            Assert.NotEmpty(queries);
        }
    }
}
