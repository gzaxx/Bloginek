using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Bloginek.Data.SQLite
{
    internal class SqliteConnection : IDisposable
    {
        private bool _disposed;
        private readonly System.Data.SQLite.SQLiteConnection _connection;

        public SqliteConnection(IConnection connection)
        {
            AssureConnectionIsNotDisposed();

            _connection = new SQLiteConnection(connection.ConnectionString);
        }

        public void Execute(CommandDefinition command)
        {
            AssureConnectionIsNotDisposed();

            _connection.Execute(command);
        }

        public T Get<T>(CommandDefinition command)
        {
            AssureConnectionIsNotDisposed();

            return _connection.QueryFirst<T>(command);
        }

        public IEnumerable<T> GetAll<T>(CommandDefinition command)
        {
            AssureConnectionIsNotDisposed();

            return _connection.Query<T>(command);
        }

        protected void AssureConnectionIsOpen()
        {
            AssureConnectionIsNotDisposed();

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        protected void AssureConnectionIsNotDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("connection");
            }
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            _connection.Dispose();
        }
    }
}
