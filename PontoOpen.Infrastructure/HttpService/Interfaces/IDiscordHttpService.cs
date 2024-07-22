using PontoOpen.Infrastructure.Models;

namespace PontoOpen.Infrastructure.HttpService.Interfaces;

public interface IDiscordHttpService
{
    Task NotifyAsync(DiscordModel discordModel, string webHookId, string webHookToken);
}
