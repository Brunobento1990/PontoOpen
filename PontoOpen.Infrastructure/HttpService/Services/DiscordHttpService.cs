using PontoOpen.Infrastructure.HttpService.Interfaces;
using PontoOpen.Infrastructure.Models;
using System.Net.Http.Headers;

namespace PontoOpen.Infrastructure.HttpService.Services;

public sealed class DiscordHttpService : IDiscordHttpService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DiscordHttpService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task NotifyAsync(DiscordModel discordModel, string webHookId, string webHookToken)
    {
        if (string.IsNullOrWhiteSpace(webHookId))
            throw new Exception("Web hook Id do discord inválidas");

        if (string.IsNullOrWhiteSpace(webHookToken))
            throw new Exception("Web hook Token do discord inválidas");

        var url = $"{webHookId}/{webHookToken}";
        var httpClient = _httpClientFactory.CreateClient("Discord");
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        await httpClient.PostAsync(url, discordModel.ToJson());
    }
}
