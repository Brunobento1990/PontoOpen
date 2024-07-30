using Microsoft.Extensions.DependencyInjection;
using PontoOpen.Infrastructure.HttpService.Interfaces;
using PontoOpen.Infrastructure.HttpService.Services;

namespace PontoOpen.IoC.Infrastructure;

public static class HttpDependencyInject
{
    public static IServiceCollection InjectHttpDiscord(this IServiceCollection services, string urlDiscord, string urlGoogleApi)
    {
        services.AddTransient<IGoogleHttpService, GoogleHttpService>();
        services.AddTransient<IDiscordHttpService, DiscordHttpService>();
        services.AddHttpClient("Discord", x =>
        {
            x.BaseAddress = new Uri(urlDiscord);
        });
        services.AddHttpClient("ApiGoogle", x =>
        {
            x.BaseAddress = new Uri(urlGoogleApi);
        });

        return services;
    }
}
