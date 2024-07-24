namespace PontoOpen.Api.Config;

public static class ConfiguraCors
{
    public static IServiceCollection ConfigurationCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: "base",
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();
                              });
        });

        return services; 
    }
}
