using PontoOpen.Infrastructure.Models;

namespace PontoOpen.Infrastructure.HttpService.Interfaces;

public interface IGoogleHttpService
{
    Task<ResponseApiLocalizacaoGoogle> GetAddressByLocationAsync(string latitude, string longitude);
}
