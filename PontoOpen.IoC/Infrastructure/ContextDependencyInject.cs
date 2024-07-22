using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PontoOpen.Infrastructure.Context;

namespace PontoOpen.IoC.Infrastructure;

public static class ContextDependencyInject
{
    public static IServiceCollection InjectContext(this IServiceCollection services, string connectionString)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));

        return services;
    }
}
