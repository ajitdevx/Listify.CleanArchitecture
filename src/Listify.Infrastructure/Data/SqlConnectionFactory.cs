using Listify.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Listify.Infrastructure.Data
{
    internal class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string? _connectionString;
        public SqlConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer");

            if (string.IsNullOrEmpty(_connectionString))
                throw new ArgumentNullException(_connectionString, "Connection string can't be null");

        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
