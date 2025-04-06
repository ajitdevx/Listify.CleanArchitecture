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
        public TodoListRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<int> AddAsync(TodoListEntity entity)
        {
            entity.CreatedOn = DateTime.Now;
            const string sql = @"
            INSERT INTO TodoLists (Title, Description, CreatedOn, CreatedBy, LastModifiedOn)
            VALUES (@Title, @Description, @CreatedOn, @CreatedBy, @CreatedOn)
            SELECT CAST(SCOPE_IDENTITY() as int)";
            using var connection = _sqlConnectionFactory.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, entity);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM TodoLists WHERE Id = @Id";
            using var connection = _sqlConnectionFactory.CreateConnection();
            await connection.ExecuteAsync(sql, new { id });
        }

        public async Task<IEnumerable<TodoListEntity>> GetAllAsync()
        {
            var sql = "SELECT Title, Description, CreatedOn, CreatedBy, LastModifiedOn, LastModifiedBy FROM TodoLists";
            using var connection = _sqlConnectionFactory.CreateConnection();
            return await connection.QueryAsync<TodoListEntity>(sql);
        }

        public async Task<TodoListEntity?> GetByIdAsync(int id)
        {
            var sql = "SELECT Title, Description, CreatedOn, CreatedBy, LastModifiedOn, LastModifiedBy FROM TodoLists WHERE Id = @id";
            using var connection = _sqlConnectionFactory.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<TodoListEntity>(sql, new { id });
        }

        public async Task UpdateAsync(TodoListEntity entity, int id)
        {
            entity.LastModifiedOn = DateTime.Now;
            var sql = @"UPDATE TodoLists SET Title = @Title, Description = @Description, LastModifiedOn = @LastModifiedOn WHERE Id = @Id";
            using var connection = _sqlConnectionFactory.CreateConnection();
            await connection.ExecuteAsync(sql, new { entity.Title, entity.Description, entity.LastModifiedOn, id });
        }
    }
}
