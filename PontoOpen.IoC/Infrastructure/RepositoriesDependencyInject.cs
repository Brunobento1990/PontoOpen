using Microsoft.Extensions.DependencyInjection;
using PontoOpen.Domain.Interfaces;
using PontoOpen.Infrastructure.Repositories;

namespace PontoOpen.IoC.Infrastructure;

public static class RepositoriesDependencyInject
{
    public static IServiceCollection InjectRepositories(this IServiceCollection services)
    {
        services.AddScoped<ILoginRepository, LoginRepository>();
        services.AddScoped<IEmpresaRepository, EmpresaRepository>();

        return services;
    }
}
