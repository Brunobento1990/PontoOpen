using Microsoft.Extensions.DependencyInjection;
using PontoOpen.Application.Interfaces;
using PontoOpen.Application.Services;

namespace PontoOpen.IoC.Application;

public static class DependencyInjectServices
{
    public static IServiceCollection InjectServices(this IServiceCollection services)
    {
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IPontoService, PontoService>();

        return services;
    }
}
