using Listify.Domain.Entities;
using Listify.Domain.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Listify.Infrastructure.Repositories
{
    internal class TodoListRepository : ITodoListRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly Func<IDbTransaction?> _transactionProvider;
        public TodoListRepository(ISqlConnectionFactory sqlConnectionFactory, Func<IDbTransaction?> transactionProvider)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _transactionProvider = transactionProvider;
        }

        public async Task<int> AddAsync(TodoListEntity entity)
        {
            entity.CreatedOn = DateTime.Now;
            const string sql = @"
            INSERT INTO TodoLists (Title, Description, Colour_Code, CreatedOn, CreatedBy)
            VALUES (@Title, @Description, @Colour, @CreatedOn, @CreatedBy)
            SELECT CAST(SCOPE_IDENTITY() as int)";
            using var connection = _sqlConnectionFactory.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, entity, transaction: _transactionProvider());
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoListEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TodoListEntity?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TodoListEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
