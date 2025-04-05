using Listify.Domain.Entities;
using Listify.Domain.Interfaces;
using Listify.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace Listify.Infrastructure.Data
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private IDbConnection? _connection;
        private IDbTransaction? _transaction;
        private bool _disposed;
        private ITodoListRepository? _todoListRepository;

        public UnitOfWork(ISqlConnectionFactory connectionFactory)
        {
            _sqlConnectionFactory = connectionFactory;
        }

        public ITodoListRepository TodoLists => _todoListRepository ??=
            new TodoListRepository(_sqlConnectionFactory, () => _transaction);

        public async Task BeginAsync()
        {
            _connection = _sqlConnectionFactory.CreateConnection();
            await Task.Run(() => _connection.Open());
            _transaction = _connection.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            try
            {
                await Task.Run(() => _transaction?.Commit());
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }

                if (_connection != null)
                {
                    _connection.Close();
                    _connection = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task RollbackAsync()
        {
            try
            {
                await Task.Run(() => _transaction?.Rollback());
            }
            finally
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }

                if (_connection != null)
                {
                    _connection.Close();
                    _connection = null;
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _connection?.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
