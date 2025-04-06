using Listify.Domain.Interfaces;
using Listify.Infrastructure.Data;
using Listify.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITodoListRepository, TodoListRepository>();
            services.AddTransient<ITodoItemRepository, TodoItemRepository>();
            return services;
        }
    }
}
