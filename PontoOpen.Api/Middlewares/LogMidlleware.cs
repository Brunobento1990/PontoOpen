using PontoOpen.Api.Config;
using PontoOpen.Application.ViewModels;
using PontoOpen.Infrastructure.HttpService.Interfaces;
using PontoOpen.Infrastructure.Models;
using System.Text.Json;

namespace PontoOpen.Api.Middlewares;

public class LogMidlleware
{
    private readonly RequestDelegate _next;
    public LogMidlleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, IDiscordHttpService discordHttpService)
    {
        try
        {
            await _next(httpContext);

            var empresaId = (string?)httpContext.Request.Headers.FirstOrDefault(x => x.Key == "EmpresaId").Value ?? "EmpresaId não lozalizada!";
            var usuarioId = (string?)httpContext.Request.Headers.FirstOrDefault(x => x.Key == "UsuarioId").Value ?? "Usuario não lozalizada!";
            var mensagem = $"{httpContext.Request.Path} \\n EmpresaId: {empresaId} \\n UsuarioId: {usuarioId}";
            var discordModel = GetDiscordModel(mensagem, 008000, titulo: "Acesso da rota!");
            await NotificarDiscord(discordModel, discordHttpService);
        }
        catch (Exception ex)
        {
            var discordModel = GetDiscordModel(ex.InnerException?.Message ?? ex.Message, 0xFF0000, titulo: "Erro");
            await NotificarDiscord(discordModel, discordHttpService, erro: true);
            await HandleError(httpContext, "Ocorreu um erro interno, tente novamente mais tarde!", 400);
        }
    }

    static DiscordModel GetDiscordModel(string message, int color, string? titulo = null)
    {
        return new DiscordModel()
        {
            Content = "Log do app",
            Username = "App ponto open",
            Embeds =
                [
                    new()
                    {
                        Description = message,
                        Title = titulo ?? "Acesso api Ponto Open",
                        Color = color
                    }
                ]
        };
    }

    static async Task HandleError(HttpContext httpContext, string mensagem, int statusCode)
    {
        httpContext.Response.Headers.Append("Access-Control-Allow-Origin", "*");
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;
        var errorResponse = new ErrorResponse(mensagem);
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }

    static async Task NotificarDiscord(DiscordModel discordModel, IDiscordHttpService discordHttpService, bool erro = false)
    {
        try
        {
            var webHookId = VariaveisDeAmbiente.GetVariavel("DISCORD_WEB_HOOK_ID");
            var webHookToken = VariaveisDeAmbiente.GetVariavel("DISCORD_WEB_HOOK_TOKEN");

            if (erro)
            {
                webHookId = VariaveisDeAmbiente.GetVariavel("DISCORD_WEB_HOOK_ID_ERRO");
                webHookToken = VariaveisDeAmbiente.GetVariavel("DISCORD_WEB_HOOK_TOKEN_ERRO");
            }

            await discordHttpService.NotifyAsync(discordModel, webHookId, webHookToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
        }
    }
}
