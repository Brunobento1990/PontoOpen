using PontoOpen.Infrastructure.HttpService.Interfaces;
using PontoOpen.Infrastructure.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PontoOpen.Infrastructure.HttpService.Services;

public sealed class GoogleHttpService : IGoogleHttpService
{
    private const string _url = "/maps/api/geocode/json?language=pt-BR&latlng={0},{1}&location_type=ROOFTOP&result_type={2}&key={3}";
    private const string _premise = "premise";
    private const string _street_address = "street_address";
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ConfiguracaoApiGoogle _configuracaoApiGoogle;
    private const int TENTATIVAS = 3;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReferenceHandler = ReferenceHandler.Preserve,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    public GoogleHttpService(
        IHttpClientFactory httpClientFactory,
        ConfiguracaoApiGoogle configuracaoApiGoogle)
    {
        _httpClientFactory = httpClientFactory;
        _configuracaoApiGoogle = configuracaoApiGoogle;
    }

    public async Task<ResponseApiLocalizacaoGoogle> GetAddressByLocationAsync(string latitude, string longitude)
    {
        var client = _httpClientFactory.CreateClient("ApiGoogle");
        var url = string.Format(_url, latitude, longitude, _premise, _configuracaoApiGoogle.ApiKey);
        int _tentativas = 0;
        while (_tentativas < TENTATIVAS)
        {
            _tentativas++;

            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                if (_tentativas == TENTATIVAS)
                {
                    Console.WriteLine(content);
                    throw new Exception(content ?? "Erro na consulta de licalização do google!");
                }
                continue;
            }

            var result = JsonSerializer.Deserialize<ResponseApiLocalizacaoGoogle>(content, _jsonSerializerOptions)
                ?? throw new Exception("Erro na desserelização do objeto de resposta da api do google!");

            if (result.Status.ToUpper() == "ZERO_RESULTS")
            {
                url = string.Format(_url, latitude, longitude, _street_address, _configuracaoApiGoogle.ApiKey);
                continue;
            }

            return result;
        }

        throw new Exception("Erro desconhecido na consulta da api google!");
    }
}
