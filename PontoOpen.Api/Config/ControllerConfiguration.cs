using System.Text.Json.Serialization;

namespace PontoOpen.Api.Config;

public static class ControllerConfiguration
{
    public static IServiceCollection ConfigureController(this  IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
