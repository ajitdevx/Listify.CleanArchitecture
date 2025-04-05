using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Listify.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }

}
