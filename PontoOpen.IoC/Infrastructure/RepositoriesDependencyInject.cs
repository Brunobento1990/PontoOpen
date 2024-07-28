using Microsoft.Extensions.DependencyInjection;
using PontoOpen.Domain.Interfaces;
using PontoOpen.Infrastructure.Models;
using PontoOpen.Infrastructure.Repositories;

namespace PontoOpen.IoC.Infrastructure;

public static class RepositoriesDependencyInject
{
    public static IServiceCollection InjectRepositories(this IServiceCollection services)
    {
        services.AddScoped<ILoginRepository, LoginRepository>();
        services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        services.AddScoped<IPontoRepository, PontoRepository>();
        services.AddScoped<IUsuarioAutenticado, UsuarioAutenticado>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }
}
