namespace PontoOpen.Api.Middlewares;

public static class InjectMiddleware
{

    public static void AddMiddlewaresApi(this WebApplication app)
    {
        app.UseMiddleware<LogMidlleware>();
        app.UseMiddleware<AutenticationUsuarioMiddleware>();
    }
}
