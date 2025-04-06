using Dapper;
using Listify.Domain.Entities;
using Listify.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Infrastructure.Repositories
{
    internal class TodoItemRepository : ITodoItemRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public TodoItemRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<int> AddAsync(TodoItemEntity entity)
        {
            entity.CreatedOn = DateTime.Now;
            var sql = @"INSERT INTO TodoItems (ListId, Title, Priority, Done, CreatedOn, CreatedBy, LastModifiedOn)
                    VALUES(@ListId, @Title, @Done, @Priority,  @CreatedOn, @CreatedBy, @CreatedOn)";
            using var connection = _sqlConnectionFactory.CreateConnection();
            return await connection.ExecuteAsync(sql, entity);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM TodoItems WHERE Id = @Id";
            using var connection = _sqlConnectionFactory.CreateConnection();
            await connection.ExecuteAsync(sql, new { id });
        }

        public async Task<IEnumerable<TodoItemEntity>> GetAllAsync()
        {
            var sql = "SELECT ListId, Title, Note, Priority, Remainder, Done, CreatedOn, CreatedBy, LastModifiedOn, LastModifiedBy FROM TodoItems";
            using var connection = _sqlConnectionFactory.CreateConnection();
            return await connection.QueryAsync<TodoItemEntity>(sql);
        }

        public async Task<TodoItemEntity?> GetByIdAsync(int id)
        {
            var sql = "SELECT ListId, Title, Note, Priority, Remainder, Done, CreatedOn, CreatedBy, LastModifiedOn, LastModifiedBy FROM TodoItems WHERE Id = @Id";
            using var connection = _sqlConnectionFactory.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<TodoItemEntity>(sql, new { id });
        }

        public async Task UpdateAsync(TodoItemEntity entity, int id)
        {
            entity.LastModifiedOn = DateTime.Now;
            var sql = @"UPDATE TodoItems SET Title = @Title, LastModifiedOn = @LastModifiedOn WHERE Id = @Id";
            using var connection = _sqlConnectionFactory.CreateConnection();
            await connection.ExecuteAsync(sql, new { entity.Title, entity.LastModifiedOn, id });
        }
    }
}
