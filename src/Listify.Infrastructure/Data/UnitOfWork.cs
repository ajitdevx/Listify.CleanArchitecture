using Listify.Domain.Entities;
using Listify.Domain.Interfaces;
using System.Data;

namespace Listify.Infrastructure.Data
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private IDbConnection _connection;
        private readonly IRepository<TodoListEntity> _todoLists;
        private readonly IRepository<TodoItemEntity> _todoItems;
        public UnitOfWork(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _todoLists = _todoLists ??= new Repository<TodoListEntity>(_sqlConnectionFactory);
            _todoItems = _todoItems ??= new Repository<TodoItemEntity>(_sqlConnectionFactory);
        }
        public IRepository<TodoListEntity> TodoLists => _todoLists;
        public IRepository<TodoItemEntity> TodoItems => _todoItems;

        public Task<int> CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
