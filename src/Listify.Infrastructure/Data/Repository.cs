using Dapper;
using Listify.Domain.Common;
using Listify.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Infrastructure.Data
{
    internal class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public Repository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            var query = $"SELECT * FROM {typeof(T).Name}s WHERE Id = @Id";
            using var connection = _sqlConnectionFactory.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<T>(query, new { Id = id });
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = $"SELECT * FROM {typeof(T).Name}s";
            using var connection = _sqlConnectionFactory.CreateConnection();
            return await connection.QueryAsync<T>(query);
        }

        public async Task<int> AddAsync(T entity)
        {
            var query = $"INSERT INTO {typeof(T).Name}s VALUES (@Entity)";
            using var connection = _sqlConnectionFactory.CreateConnection();
            return await connection.ExecuteAsync(query, new { Entity = entity });
        }

        public async Task UpdateAsync(T entity)
        {
            var query = $"UPDATE {typeof(T).Name}s SET @Entity WHERE Id = @Id";
            using var connection = _sqlConnectionFactory.CreateConnection();
            await connection.ExecuteAsync(query, new { Entity = entity });
        }

        public async Task DeleteAsync(int id)
        {
            var query = $"DELETE FROM {typeof(T).Name}s WHERE Id = @Id";
            using var connection = _sqlConnectionFactory.CreateConnection();
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
